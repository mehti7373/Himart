using Core.Domain.PersonAggregate.Events;
using Core.Domain.Shared.ValueObjects;
using Core.Domain.UserAggregate.ValueObjects;
using Framework.Domain.Events;
using Framework.Domain.Models;

namespace Core.Domain.UserAggregate.Entities;

public class UserEntity : AggregateRoot<UserEntity, Guid>
{
    public Username Username { get; private set; }
    public Password Password { get; private set; }
    public Email Email { get; private set; }
    public PersonId PersonId { get; private set; }
    public UserRole Role { get; private set; }
    public PersonId CreatorPersonId { get; private set; }
    public CreateAt CreateAt { get; private set; }

    private UserEntity()
    {
    }

    public UserEntity(Username username,
                      Password password,
                      Email email,
                      PersonId personId,
                      UserRole role,
                      PersonId creatorPersonId)
    {
        Username = username;
        Password = password;
        Email = email;
        PersonId = personId;
        Role = role;
        CreatorPersonId = creatorPersonId;
        CreateAt = CreateAt.Now;
        AddDomainEvent(new UserEntityCreatedDomainEvent(Username,
                                                        Password,
                                                        Email,
                                                        PersonId,
                                                        Role,
                                                        CreatorPersonId,
                                                        CreateAt));

    }
}