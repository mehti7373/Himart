using Framework.Domain.Models;

namespace Core.Domain.PersonAggregate.ValueObjects;

public record BirthDate : BaseValueObject
{
    public DateOnly Value { get; private set; }
}
