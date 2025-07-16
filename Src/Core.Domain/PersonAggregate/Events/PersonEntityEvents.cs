using Core.Domain.PersonAggregate.ValueObjects;
using Framework.Domain.Events;

namespace Core.Domain.PersonAggregate.Events;

public record PersonEntityCreatedDomainEvent(Name name,
                                             Family family,
                                             NationalCode nationalCode,
                                             BirthDate birthDate) : IDomainEvent;

