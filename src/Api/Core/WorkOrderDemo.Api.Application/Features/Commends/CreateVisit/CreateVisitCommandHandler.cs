using AutoMapper;
using MediatR;
using WorkOrderDemo.Api.Application.Features.Queries.ViewModels;
using WorkOrderDemo.Api.Application.Interfaces.Repositories;
using WorkOrderDemo.Api.Domain.AggregateModels.VisitAggregate;

namespace WorkOrderDemo.Api.Application.Features.Commends.CreateVisit;

public class CreateVisitCommandHandler : IRequestHandler<CreateVisitCommand, VisitDetail>
{
    private readonly IVisitRepository _visitRepository;
    private readonly IMapper _mapper;

    public CreateVisitCommandHandler(IVisitRepository visitRepository, IMapper mapper)
    {
        _visitRepository = visitRepository;
        _mapper = mapper;
    }

    public async Task<VisitDetail> Handle(CreateVisitCommand request, CancellationToken cancellationToken)
    {
        var visit = new Visit(request.WorkOrderId,request.VisitorName,request.VisitDate);

        request.VisitParts.ToList().ForEach(vp => visit.AddVisitPart(vp.Name, vp.Quantity, vp.Price));

        var addedVisit = await _visitRepository.AddAsync(visit);
        await _visitRepository.UnitOfWork.SaveChangesAsync();

        var result = _mapper.Map<VisitDetail>(addedVisit);

        return result;
    }
}
