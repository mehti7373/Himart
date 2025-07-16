using Core.Domain.Shared.ValueObjects;
using Core.Domain.TaskAggregate.ValueObjects;
using Framework.Domain.Events;

namespace Core.Domain.TaskAggregate.Events;
public record TaskEntityCreatedEvent(Title Title,
                                     Status Status,
                                     CheckOutDate? CheckOutDate,
                                     CreateAt CreateAt,
                                     CreatorUserId CreatorUserId) : IDomainEvent;
public record TaskEntityUpdatedEvent(Guid Id,
                                     Title Title,
                                     Status Status,
                                     CheckOutDate? CheckOutDate) : IDomainEvent;
