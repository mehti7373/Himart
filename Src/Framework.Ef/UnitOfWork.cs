using Framework.Domain.Events;
using Framework.Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Framework.Ef;

public class UnitOfWork<TDbContext> : IUnitOfWork, IDisposable where TDbContext : DbContext
{
    private readonly TDbContext _context;

    private readonly IMediator _mediator;

    public UnitOfWork(TDbContext context, IMediator mediator)
    {
        _context = context;
        _mediator = mediator;
    }

    public void Dispose()
    {
        _context.Dispose();
    }

    public async Task<int> SaveChangesAsync()
    {
        IList<EntityEntry> entries = GetEntries();
        int count = await _context.SaveChangesAsync();
        IList<IDomainEvent> events = GetEvents(entries);
        ClearEvents(entries);
        await RaiseEvents(events);
        return count;
    }

    private static List<IDomainEvent> GetEvents(IList<EntityEntry> entries)
    {
        return entries.Where((EntityEntry x) => x.Entity.GetType().IsAssignableTo(typeof(IEventfulEntity)))
            .SelectMany((EntityEntry x) => ((IEventfulEntity)x.Entity).GetDomainEvents())
            .ToList();
    }

    private static void ClearEvents(IList<EntityEntry> entries)
    {
        (from x in entries
         where x.Entity.GetType().IsAssignableTo(typeof(IEventfulEntity))
         select (IEventfulEntity)x.Entity).ToList().ForEach(delegate (IEventfulEntity x)
         {
             x.ClearDomainEvents();
         });
    }

    private Task RaiseEvents(IList<IDomainEvent> events)
    {
        return Task.WhenAll(events.Select((IDomainEvent @event) => _mediator.Publish(@event)));
    }

    private IList<EntityEntry> GetEntries()
    {
        return (from x in _context.ChangeTracker.Entries()
                where new EntityState[3]
                {
                EntityState.Modified,
                EntityState.Added,
                EntityState.Deleted
                }.Contains(x.State)
                select x).ToList();
    }
}