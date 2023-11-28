using AutoMapper;
using MediatR;
using WorkOrderDemo.Api.Application.Features.Queries.ViewModels;
using WorkOrderDemo.Api.Application.Interfaces.Repositories;
using WorkOrderDemo.Api.Domain.AggregateModels.WorkOrderAggregate;

namespace WorkOrderDemo.Api.Application.Features.Commends.CreateWorkOrder;

public class CreateWorkOrderCommandHandler : IRequestHandler<CreateWorkOrderCommand, WorkOrderDetail>
{
    private readonly IWorkOrderRepository _workOrderRepository;
    private readonly IMapper _mapper;

    public CreateWorkOrderCommandHandler(IWorkOrderRepository workOrderRepository, IMapper mapper)
    {
        _workOrderRepository = workOrderRepository;
        _mapper = mapper;
    }

    public async Task<WorkOrderDetail> Handle(CreateWorkOrderCommand request, CancellationToken cancellationToken)
    {
        var workOrder = new WorkOrder(request.OrderImportanceId, request.Deadline, request.OrderingCompanyName, request.Description);


        var addedWorkOrder = await _workOrderRepository.AddAsync(workOrder);
        await _workOrderRepository.UnitOfWork.SaveChangesAsync(cancellationToken);

        var result = _mapper.Map<WorkOrderDetail>(addedWorkOrder);

        return result;
    }
}
