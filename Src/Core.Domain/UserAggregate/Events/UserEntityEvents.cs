using Core.Domain.Shared.ValueObjects;
using Core.Domain.UserAggregate.ValueObjects;
using Framework.Domain.Events;

namespace Core.Domain.PersonAggregate.Events;


public record UserEntityCreatedDomainEvent(Username username,
                                           Password password,
                                           Email email,
                                           PersonId personId,
                                           UserRole role,
                                           PersonId creatorPersonId,
                                           CreateAt createAt) : IDomainEvent;
