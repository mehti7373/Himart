using Framework.Domain.Models;

namespace Core.Domain.UserAggregate.ValueObjects;

public record UserRole : Enumeration<UserRole>
{
    public UserRole(int id, string name) : base(id,name)
    {
    }


    public static UserRole SystemUser => new UserRole(1,nameof(SystemUser));
    public static UserRole Admin => new UserRole(1,nameof(Admin));
}
