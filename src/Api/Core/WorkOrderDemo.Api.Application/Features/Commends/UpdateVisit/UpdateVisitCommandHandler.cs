using AutoMapper;
using MediatR;
using WorkOrderDemo.Api.Application.Features.Queries.ViewModels;
using WorkOrderDemo.Api.Application.Interfaces.Repositories;
using WorkOrderDemo.Api.Domain.AggregateModels.VisitAggregate;

namespace WorkOrderDemo.Api.Application.Features.Commends.UpdateVisit;

public class UpdateVisitCommandHandler : IRequestHandler<UpdateVisitCommand, VisitDetail>
{
    private readonly IMapper _mapper;
    private readonly IVisitRepository _visitRepository;

    public UpdateVisitCommandHandler(IMapper mapper, IVisitRepository visitRepository)
    {
        _mapper = mapper;
        _visitRepository = visitRepository;
    }

    public async Task<VisitDetail> Handle(UpdateVisitCommand request, CancellationToken cancellationToken)
    {
        var visit = new Visit(request.Id, request.WorkOrderId, request.VisitorName, request.VisitDate);

        request.VisitParts.ToList().ForEach(vp => visit.AddVisitPart(vp.Id == null ? Guid.NewGuid() : (Guid)vp.Id, vp.Name, vp.Quantity, vp.Price));

        var updatedVisit = await _visitRepository.UpdateWithPartsAsync(visit);

        var result = _mapper.Map<VisitDetail>(updatedVisit);

        return result;
    }
}
