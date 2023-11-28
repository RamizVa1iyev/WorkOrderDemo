using AutoMapper;
using MediatR;
using WorkOrderDemo.Api.Application.Features.Queries.ViewModels;
using WorkOrderDemo.Api.Application.Interfaces.Repositories;

namespace WorkOrderDemo.Api.Application.Features.Queries.GetWorkOrderDetailById;

public class GetWorkOrderDetailByIdQueryHandler : IRequestHandler<GetWorkOrderDetailByIdQuery, WorkOrderDetail>
{

    private readonly IWorkOrderRepository _workOrderRepository;

    public GetWorkOrderDetailByIdQueryHandler(IWorkOrderRepository workOrderRepository)
    {
        _workOrderRepository = workOrderRepository;
    }


    public async Task<WorkOrderDetail> Handle(GetWorkOrderDetailByIdQuery request, CancellationToken cancellationToken)
    {
        var workOrder = await _workOrderRepository.GetDetailWithCountAsync(w => w.Id == request.WorkOrderId);

        return workOrder;
    }
}
