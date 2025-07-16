using Framework.Domain.Models;

namespace Core.Domain.UserAggregate.ValueObjects;

public record PersonId : BaseValueObject
{
    public Guid Value { get; private set; }
}
