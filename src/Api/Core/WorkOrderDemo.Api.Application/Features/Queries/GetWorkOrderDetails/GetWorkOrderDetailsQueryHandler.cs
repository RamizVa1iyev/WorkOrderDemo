using MediatR;
using WorkOrderDemo.Api.Application.Features.Queries.ViewModels;
using WorkOrderDemo.Api.Application.Interfaces.Repositories;
using WorkOrderDemo.Api.Domain.SeedWork.Paging;

namespace WorkOrderDemo.Api.Application.Features.Queries.GetWorkOrderDetails;

public class GetWorkOrderDetailsQueryHandler : IRequestHandler<GetWorkOrderDetailsQuery, IPaginate<WorkOrderDetail>>
{
    private readonly IWorkOrderRepository _workOrderRepository;

    public GetWorkOrderDetailsQueryHandler(IWorkOrderRepository workOrderRepository)
    {
        _workOrderRepository = workOrderRepository;
    }

    public async Task<IPaginate<WorkOrderDetail>> Handle(GetWorkOrderDetailsQuery request, CancellationToken cancellationToken)
    {
        var result = await _workOrderRepository.GetDetailsWithCountAsync(request.Index, request.Size);


        return result;
    }
}
