
namespace WorkOrderDemo.Api.Domain.Exceptions;

public class WorkOrderException : Exception
{
    public WorkOrderException() { }

    public WorkOrderException(string exception) : base(exception) { }

    public WorkOrderException(string exception, Exception innerException) : base(exception, innerException) { }
    public static void ThrowIfNull(object? obj, string name)
    {
        if (obj == null)
            throw new WorkOrderException($"{nameof(obj)} cannot be empty");
    }

    public static void ThrowIfNullOrEmpty(string value, string name)
    {
        if (String.IsNullOrEmpty(value))
            throw new WorkOrderException($"{nameof(value)} cannot be empty");
    }

    public static void ThrowIfDefault(object? obj, string name)
    {
        if (obj == default)
            throw new WorkOrderException($"{nameof(obj)} cannot be empty");
    }
}
