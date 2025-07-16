using Framework.Domain.Models;

namespace Core.Domain.UserAggregate.ValueObjects;

public record Username : BaseValueObject
{
    public string Value { get; private set; }
    protected Username(string value)
    {
        if (string.IsNullOrWhiteSpace(value) || value.Length > 100)
            throw Exceptions.InvalidUsernameException.Create();

        Value = value;
    }
    public static Username Parse(string value) => new(value);
}
