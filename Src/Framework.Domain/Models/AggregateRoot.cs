using Framework.Domain.Events;

namespace Framework.Domain.Models;
public abstract class AggregateRoot<TAggregateRoot, TId> : BaseEntity<TAggregateRoot, TId>, IEventfulEntity where TAggregateRoot : AggregateRoot<TAggregateRoot, TId> where TId : struct
{
    private readonly IList<IDomainEvent> _domainEvents;

    protected AggregateRoot()
    {
        _domainEvents = new List<IDomainEvent>();
    }

    protected void AddDomainEvent(IDomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }

    public void ClearDomainEvents()
    {
        _domainEvents?.Clear();
    }

    public IReadOnlyCollection<IDomainEvent> GetDomainEvents()
    {
        return _domainEvents.AsReadOnly();
    }
}