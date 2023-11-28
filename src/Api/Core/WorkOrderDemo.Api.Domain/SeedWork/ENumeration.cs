
using System.Reflection;

namespace WorkOrderDemo.Api.Domain.SeedWork;

public abstract class ENumeration : IComparable
{
    public string Name { get; private set; }
    public int Id { get; private set; }

    protected ENumeration(int id, string name) => (Id, Name) = (id, name);

    public static IEnumerable<T> GetAll<T>() where T : ENumeration =>
        typeof(T).GetFields(BindingFlags.Public |
                           BindingFlags.Static |
                           BindingFlags.DeclaredOnly)
                 .Select(f => f.GetValue(null))
                 .Cast<T>();

    public override bool Equals(object? obj)
    {
        if (obj is not ENumeration otherValue)
            return false;

        var typeMatches = GetType().Equals(obj.GetType());
        var valueMatches = Id.Equals(otherValue.Id);

        return typeMatches && valueMatches;
    }

    public static T FromValue<T>(int value) where T : ENumeration
    {
        var matchingItem = Parse<T, int>(value, "value", item => item.Id == value);
        return matchingItem;
    }

    public static T FromDisplayName<T>(string displayName) where T : ENumeration
    {
        var matchingItem = Parse<T,string>(displayName,"display name",item=>item.Name==displayName);
        return matchingItem;
    }

    public override int GetHashCode() => Id.GetHashCode();

    private static T Parse<T,K>(K value,string description, Func<T,bool> predicate) where T : ENumeration
    {
        var matchingItem = GetAll<T>().FirstOrDefault(predicate);

        if (matchingItem is null)
            throw new InvalidOperationException($"'{value}' is not a valid '{description}' in {typeof(T)}");

        return matchingItem;
    }

    public int CompareTo(object? obj) => Id.CompareTo(((ENumeration)obj).Id);
}
