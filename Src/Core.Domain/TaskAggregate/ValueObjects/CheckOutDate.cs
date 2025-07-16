using Framework.Domain.Models;

namespace Core.Domain.TaskAggregate.ValueObjects;

public record CheckOutDate : BaseValueObject
{
    public DateOnly Value { get; private set; }

    private CheckOutDate()
    {
    }
    public CheckOutDate(DateOnly value)
    {
        Value = value;
    }

    public static CheckOutDate Parse(DateOnly value) => new(value);
}
