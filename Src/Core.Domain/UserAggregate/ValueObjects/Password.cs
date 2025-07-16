using Framework.Domain.Models;

namespace Core.Domain.UserAggregate.ValueObjects;

public record Password : BaseValueObject
{
    public string Value { get; private set; }
    protected Password(string value)
    {
        if (string.IsNullOrWhiteSpace(value) || value.Length > 100)
            throw Exceptions.InvalidPasswordException.Create();

        Value = value + "hashed";
    }
    public static Password Parse(string value) => new(value);
}