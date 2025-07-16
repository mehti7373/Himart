using Core.Domain.PersonAggregate.ValueObjects;
using Framework.Domain.Models;

namespace Core.Domain.PersonAggregate.Entities;

public class PersonEntity : AggregateRoot<PersonEntity, Guid>
{
    public Name Name { get; private set; }
    public Family Family { get; private set; }
    public NationalCode NationalCode { get; private set; }
    public BirthDate BirthDate { get; private set; }

    private PersonEntity()
    {
        
    }

    public PersonEntity(Name name,
                        Family family,
                        NationalCode nationalCode,
                        BirthDate birthDate)
    {
        Name = name;
        Family = family;
        NationalCode = nationalCode;
        BirthDate = birthDate;
        AddDomainEvent(new Events.PersonEntityCreatedDomainEvent(Name,
                                                                 Family,
                                                                 NationalCode,
                                                                 BirthDate));
    }
}
