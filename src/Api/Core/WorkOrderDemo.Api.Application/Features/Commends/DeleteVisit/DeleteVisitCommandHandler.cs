using MediatR;
using WorkOrderDemo.Api.Application.Interfaces.Repositories;
using WorkOrderDemo.Api.Domain.AggregateModels.VisitAggregate;

namespace WorkOrderDemo.Api.Application.Features.Commends.DeleteVisit;

public class DeleteVisitCommandHandler : IRequestHandler<DeleteVisitCommand, bool>
{
    private readonly IVisitRepository _visitRepository;

    public DeleteVisitCommandHandler(IVisitRepository visitRepository)
    {
        _visitRepository = visitRepository;
    }

    public async Task<bool> Handle(DeleteVisitCommand request, CancellationToken cancellationToken)
    {
        _visitRepository.Delete(new Visit(request.Id));
        await _visitRepository.UnitOfWork.SaveChangesAsync();

        return true;
    }
}
