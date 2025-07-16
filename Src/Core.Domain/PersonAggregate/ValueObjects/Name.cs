using Framework.Domain.Models;

namespace Core.Domain.PersonAggregate.ValueObjects;

public record Name : BaseValueObject
{
    public string Value { get; private set; }
}
