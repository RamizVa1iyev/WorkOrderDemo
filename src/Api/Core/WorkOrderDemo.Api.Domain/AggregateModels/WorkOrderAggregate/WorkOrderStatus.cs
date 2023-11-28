using WorkOrderDemo.Api.Domain.Exceptions;
using WorkOrderDemo.Api.Domain.SeedWork;

namespace WorkOrderDemo.Api.Domain.AggregateModels.WorkOrderAggregate;

public class WorkOrderStatus : ENumeration
{
    public static WorkOrderStatus Waiting = new(1, nameof(Waiting).ToLowerInvariant());
    public static WorkOrderStatus InProggess = new(2, nameof(InProggess).ToLowerInvariant());
    public static WorkOrderStatus Completed = new(3, nameof(Completed).ToLowerInvariant());
    public WorkOrderStatus(int id, string name) : base(id, name)
    {
    }

    public static IEnumerable<WorkOrderStatus> List()
    {
        return new[] { Waiting, InProggess, Completed, };
    }

    public static WorkOrderStatus FromName(string name)
    {
        var result = List()
            .SingleOrDefault(x => string.Equals(x.Name, name, StringComparison.InvariantCultureIgnoreCase));

        return result ?? throw new WorkOrderException($"Possible values for OrderImportance: ${string.Join(",", List().Select(s => s.Name))}");
    }

    public static WorkOrderStatus From(int id)
    {
        var result = List()
            .SingleOrDefault(x => x.Id == id);

        return result ?? throw new WorkOrderException($"Possible values for OrderImportance: ${string.Join(",", List().Select(s => s.Name))}");
    }
}
