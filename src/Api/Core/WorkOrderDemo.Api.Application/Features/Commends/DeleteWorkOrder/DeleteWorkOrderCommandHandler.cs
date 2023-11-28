using MediatR;
using WorkOrderDemo.Api.Application.Interfaces.Repositories;
using WorkOrderDemo.Api.Domain.AggregateModels.WorkOrderAggregate;

namespace WorkOrderDemo.Api.Application.Features.Commends.DeleteWorkOrder;

public class DeleteWorkOrderCommandHandler : IRequestHandler<DeleteWorkOrderCommand, bool>
{
    private readonly IWorkOrderRepository _workOrderRepository;

    public DeleteWorkOrderCommandHandler(IWorkOrderRepository workOrderRepository)
    {
        _workOrderRepository = workOrderRepository;
    }

    public async Task<bool> Handle(DeleteWorkOrderCommand request, CancellationToken cancellationToken)
    {
        _workOrderRepository.Delete(new WorkOrder(request.WorkOrderId));
        await _workOrderRepository.UnitOfWork.SaveChangesAsync();

        return true;
    }
}
