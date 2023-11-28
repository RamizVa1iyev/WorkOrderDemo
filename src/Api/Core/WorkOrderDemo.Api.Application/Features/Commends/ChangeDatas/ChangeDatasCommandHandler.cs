using MediatR;
using WorkOrderDemo.Api.Application.Features.Queries.ViewModels;
using WorkOrderDemo.Api.Application.Interfaces.Repositories;

namespace WorkOrderDemo.Api.Application.Features.Commends.ChangeDatas
{
    public class ChangeDatasCommandHandler : IRequestHandler<ChangeDatasCommand, ChangingDataInformation>
    {
        private readonly IWorkOrderRepository _workOrderRepository;

        public ChangeDatasCommandHandler(IWorkOrderRepository workOrderRepository)
        {
            _workOrderRepository = workOrderRepository;
        }

        public async Task<ChangingDataInformation> Handle(ChangeDatasCommand request, CancellationToken cancellationToken)
        {
            ChangingDataInformation result = await _workOrderRepository.ChangeDatasRandomlyAsync();

            return result;
        }
    }
}
