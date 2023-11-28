namespace WorkOrderDemo.Api.Application.Features.Queries.ViewModels;

public class WorkOrderDetail
{
    public WorkOrderDetail(Guid id, string orderImportance, string orderStatus, int orderImportanceId, int orderStatusId, DateTime deadline, string orderingCompanyName, string description, int countOfVisits, int countOfParts)
    {
        Id = id;
        OrderImportance = orderImportance;
        OrderStatus = orderStatus;
        OrderStatusId = orderStatusId;
        OrderImportanceId = orderImportanceId;
        Deadline = deadline;
        OrderingCompanyName = orderingCompanyName;
        Description = description;
        CountOfVisits = countOfVisits;
        CountOfParts = countOfParts;
    }

    public WorkOrderDetail()
    {

    }

    public Guid Id { get; init; }

    public int OrderImportanceId { get; init; }

    public string OrderImportance { get; init; }

    public int OrderStatusId { get; init; }

    public string OrderStatus { get; init; }

    public DateTime Deadline { get; init; }

    public string OrderingCompanyName { get; init; }

    public string Description { get; init; }

    public int CountOfVisits { get; init; }

    public int CountOfParts { get; init; }
}
