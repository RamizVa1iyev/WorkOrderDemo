using WorkOrderDemo.Api.Domain.AggregateModels.VisitAggregate;
using WorkOrderDemo.Api.Domain.Exceptions;
using WorkOrderDemo.Api.Domain.SeedWork;

namespace WorkOrderDemo.Api.Domain.AggregateModels.WorkOrderAggregate;

public class WorkOrder : BaseEntity, IAggregateRoot
{
    public WorkOrder()
    {
    }
    public WorkOrder(Guid id) : this()
    {
        Id = id;
    }

    public WorkOrder(Guid id, int orderImportanceId, DateTime deadline, string orderingCompanyName, string description) : this(id)
    {

        WorkOrderException.ThrowIfNullOrEmpty(orderingCompanyName, nameof(orderingCompanyName));
        WorkOrderException.ThrowIfNullOrEmpty(description, nameof(description));

        if (deadline <= DateTime.Now)
            throw new WorkOrderException("Deadline cannot be less than now");


        orderStatusId = WorkOrderStatus.Waiting.Id;
        this.orderImportanceId = orderImportanceId;
        Deadline = deadline;
        OrderingCompanyName = orderingCompanyName;
        Description = description;
    }

    public WorkOrder(int orderImportanceId, DateTime deadline, string orderingCompanyName, string description) : this(Guid.NewGuid(), orderImportanceId, deadline, orderingCompanyName, description) { }


    private int orderImportanceId;
    public WorkOrderImportance OrderImportance { get; private set; }

    private int orderStatusId;
    public WorkOrderStatus OrderStatus { get; private set; }

    public DateTime Deadline { get; private set; }

    public string OrderingCompanyName { get; private set; }

    public string Description { get; private set; }


    private readonly List<Visit> _visits;

    public IReadOnlyCollection<Visit> Visits => _visits;

    public int GetOrderStatusId() => orderStatusId;
    public int GetOrderImportanceId() => orderImportanceId;
}
