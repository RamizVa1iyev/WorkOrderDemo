using MediatR;

namespace WorkOrderDemo.Api.Application.Features.Commends.DeleteWorkOrder;

public class DeleteWorkOrderCommand:IRequest<bool>
{
    public Guid WorkOrderId { get; set; }

    public DeleteWorkOrderCommand(Guid workOrderId)
    {
        WorkOrderId = workOrderId;
    }
}
