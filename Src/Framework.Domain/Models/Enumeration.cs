using System.Reflection;

namespace Framework.Domain.Models;

public abstract record Enumeration<T> : BaseValueObject, IComparable where T : Enumeration<T>
{
    public string Name { get; private set; }

    public int Id { get; private set; }

    protected Enumeration(int id, string name)
    {
        Id = id;
        Name = name;
    }

    public sealed override string ToString()
    {
        return Name;
    }

    public static IEnumerable<T> GetAll<T>()
    {
        return (from f in typeof(T).GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Static | BindingFlags.Public)
                select f.GetValue(null)).Cast<T>();
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }

    public static T FromValue(int value)
    {
        return Parse(value, "value", (T item) => item.Id == value);
    }

    public static T FromDisplayName(string name)
    {
        string name2 = name;
        return Parse(name2, "display name", (T item) => item.Name == name2);
    }

    public static T Parse<K>(K value, string description, Func<T, bool> predicate)
    {
        return GetAll<T>().FirstOrDefault(predicate) ?? throw new InvalidOperationException($"'{value}' is not a valid {description} in {typeof(T)}");
    }

    public int CompareTo(object? obj)
    {
        return Id.CompareTo(((Enumeration<T>)obj)?.Id);
    }
}
