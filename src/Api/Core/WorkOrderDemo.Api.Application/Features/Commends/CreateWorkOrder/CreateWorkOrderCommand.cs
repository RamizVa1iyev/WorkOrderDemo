using MediatR;
using WorkOrderDemo.Api.Application.Features.Queries.ViewModels;

namespace WorkOrderDemo.Api.Application.Features.Commends.CreateWorkOrder;

public class CreateWorkOrderCommand : IRequest<WorkOrderDetail>
{
    public CreateWorkOrderCommand(int orderImportanceId, DateTime deadline, string orderingCompanyName, string description)
    {
        OrderImportanceId = orderImportanceId;
        Deadline = deadline;
        OrderingCompanyName = orderingCompanyName;
        Description = description;
    }

    public int OrderImportanceId { get; init; }

    public DateTime Deadline { get; init; }

    public string OrderingCompanyName { get; init; }

    public string Description { get; init; }
}
