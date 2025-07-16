using Framework.Domain.Models;

namespace Core.Domain.PersonAggregate.ValueObjects;

public record Family : BaseValueObject
{
    public string Value { get; private set; }
}
