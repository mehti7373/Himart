using Core.Domain.PersonAggregate.ValueObjects;
using Framework.Domain.Models;

namespace Core.Domain.TaskAggregate.ValueObjects;
public record Title : BaseValueObject
{
    public string Value { get; private set; }

    private Title(string value)
    {
        Value = value;
    }
    public static Title Parse(string title) => new(title);
}
