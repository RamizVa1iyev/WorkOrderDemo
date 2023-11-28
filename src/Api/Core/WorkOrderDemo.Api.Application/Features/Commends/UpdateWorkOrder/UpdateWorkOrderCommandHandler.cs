
using AutoMapper;
using MediatR;
using WorkOrderDemo.Api.Application.Features.Queries.ViewModels;
using WorkOrderDemo.Api.Application.Interfaces.Repositories;
using WorkOrderDemo.Api.Domain.AggregateModels.WorkOrderAggregate;

namespace WorkOrderDemo.Api.Application.Features.Commends.UpdateWorkOrder;

public class UpdateWorkOrderCommandHandler : IRequestHandler<UpdateWorkOrderCommand, WorkOrderDetail>
{
    private readonly IMapper _mapper;
    private readonly IWorkOrderRepository _workOrderRepository;

    public UpdateWorkOrderCommandHandler(IMapper mapper, IWorkOrderRepository workOrderRepository)
    {
        _mapper = mapper;
        _workOrderRepository = workOrderRepository;
    }

    public async Task<WorkOrderDetail> Handle(UpdateWorkOrderCommand request, CancellationToken cancellationToken)
    {
        var workOrder = new WorkOrder(request.Id,request.OrderImportanceId, request.Deadline, request.OrderingCompanyName, request.Description);

        var updatedWorkOrder =  _workOrderRepository.Update(workOrder);
        await _workOrderRepository.UnitOfWork.SaveChangesAsync(cancellationToken);

        var result = _mapper.Map<WorkOrderDetail>(updatedWorkOrder);

        return result;
    }
}
