namespace WorkOrderDemo.Api.Domain.Exceptions;

public class VisitException : Exception
{
    public VisitException() { }

    public VisitException(string exception) : base(exception) { }

    public VisitException(string exception, Exception innerException) : base(exception, innerException) { }

    public static void ThrowIfNull(object? obj, string name)
    {
        if (obj == null)
            throw new VisitException($"{nameof(obj)} cannot be empty");
    }

    public static void ThrowIfNullOrEmpty(string value, string name)
    {
        if (String.IsNullOrEmpty(value))
            throw new VisitException($"{nameof(value)} cannot be empty");
    }

    public static void ThrowIfDefault(object? obj, string name)
    {
        if (obj == default)
            throw new VisitException($"{nameof(obj)} cannot be empty");
    }
}
