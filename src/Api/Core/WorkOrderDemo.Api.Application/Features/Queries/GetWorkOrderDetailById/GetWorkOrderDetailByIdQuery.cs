using MediatR;
using WorkOrderDemo.Api.Application.Features.Queries.ViewModels;

namespace WorkOrderDemo.Api.Application.Features.Queries.GetWorkOrderDetailById;

public class GetWorkOrderDetailByIdQuery:IRequest<WorkOrderDetail>
{
    public Guid WorkOrderId { get; set; }

    public GetWorkOrderDetailByIdQuery(Guid workOrderId)
    {
        WorkOrderId = workOrderId;
    }
}
