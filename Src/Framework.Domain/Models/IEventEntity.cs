using Framework.Domain.Events;

namespace Framework.Domain.Models;

public interface IEventfulEntity
{
    void ClearDomainEvents();

    IReadOnlyCollection<IDomainEvent> GetDomainEvents();
}
