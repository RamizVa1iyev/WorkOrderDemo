using WorkOrderDemo.Api.Domain.Exceptions;
using WorkOrderDemo.Api.Domain.SeedWork;

namespace WorkOrderDemo.Api.Domain.AggregateModels.WorkOrderAggregate;

public class WorkOrderImportance : ENumeration
{
    public static WorkOrderImportance Routine = new(1, nameof(Routine).ToLowerInvariant());
    public static WorkOrderImportance Low = new(2, nameof(Low).ToLowerInvariant());
    public static WorkOrderImportance Medium = new(3, nameof(Medium).ToLowerInvariant());
    public static WorkOrderImportance High = new(4, nameof(High).ToLowerInvariant());
    public static WorkOrderImportance Critical = new(5, nameof(Critical).ToLowerInvariant());

    public WorkOrderImportance(int id, string name) : base(id, name)
    {
    }

    public static IEnumerable<WorkOrderImportance> List()
    {
        return new[] { Routine, Low, Medium, High, Critical };
    }

    public static WorkOrderImportance FromName(string name)
    {
        var result = List()
            .SingleOrDefault(x => string.Equals(x.Name, name, StringComparison.InvariantCultureIgnoreCase));

        return result ?? throw new WorkOrderException($"Possible values for OrderImportance: ${string.Join(",", List().Select(s => s.Name))}");
    }

    public static WorkOrderImportance From(int id)
    {
        var result = List()
            .SingleOrDefault(x => x.Id == id);

        return result ?? throw new WorkOrderException($"Possible values for OrderImportance: ${string.Join(",", List().Select(s => s.Name))}");
    }
}
