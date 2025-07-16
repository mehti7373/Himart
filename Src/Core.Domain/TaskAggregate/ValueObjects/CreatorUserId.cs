using Framework.Domain.Models;

namespace Core.Domain.TaskAggregate.ValueObjects;

public record CreatorUserId : BaseValueObject
{
    public Guid Value { get; private set; }
    private CreatorUserId(Guid value)
    {
        Value = value;
    }

    public static CreatorUserId Parse(Guid value) => new(value);
}
