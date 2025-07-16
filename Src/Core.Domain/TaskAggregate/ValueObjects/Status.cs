using Framework.Domain.Models;

namespace Core.Domain.TaskAggregate.ValueObjects;
public record Status : Enumeration<Status>
{
    public Status(int id, string name) : base(id, name)
    {
    }

    public static Status Uncompelete = new Status(1, nameof(Uncompelete));
    public static Status Compelete = new Status(1, nameof(Compelete));
}
