using Framework.Domain.Models;

namespace Core.Domain.UserAggregate.ValueObjects;

public record Email : BaseValueObject
{
    public string Value { get; private set; }
    protected Email(string value)
    {
        if (string.IsNullOrWhiteSpace(value) || value.Length > 100)
            throw Exceptions.InvalidUsernameException.Create();

        Value = value;
    }
    public static Email Parse(string value) => new(value);
}
