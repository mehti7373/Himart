using Core.Domain.TaskAggregate.ValueObjects;
using Framework.Domain.Models;

namespace Core.Domain.Shared.ValueObjects;

public record CreateAt : BaseValueObject
{
    public DateTime Value { get; private set; }

    private CreateAt()
    {
    }
    private CreateAt(DateTime value)
    {
        Value = value;
    }

    public static CreateAt Parse(DateTime value) => new(value);
    public static CreateAt Now => new(DateTime.UtcNow);
}
