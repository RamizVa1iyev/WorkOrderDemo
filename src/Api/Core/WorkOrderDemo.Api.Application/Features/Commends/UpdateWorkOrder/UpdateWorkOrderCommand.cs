using MediatR;
using System.Text.Json.Serialization;
using WorkOrderDemo.Api.Application.Features.Queries.ViewModels;

namespace WorkOrderDemo.Api.Application.Features.Commends.UpdateWorkOrder;

public class UpdateWorkOrderCommand : IRequest<WorkOrderDetail>
{
    public UpdateWorkOrderCommand(Guid id,int orderImportanceId, DateTime deadline, string orderingCompanyName, string description)
    {
        Id = id;
        OrderImportanceId = orderImportanceId;
        Deadline = deadline;
        OrderingCompanyName = orderingCompanyName;
        Description = description;
    }

    [JsonIgnore]
    public Guid Id { get; set; }

    public int OrderImportanceId { get; init; }

    public DateTime Deadline { get; init; }

    public string OrderingCompanyName { get; init; }

    public string Description { get; init; }
}
