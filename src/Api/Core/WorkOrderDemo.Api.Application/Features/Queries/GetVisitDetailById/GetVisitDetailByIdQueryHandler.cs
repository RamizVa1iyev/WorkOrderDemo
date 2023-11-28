using AutoMapper;
using MediatR;
using WorkOrderDemo.Api.Application.Features.Queries.ViewModels;
using WorkOrderDemo.Api.Application.Interfaces.Repositories;

namespace WorkOrderDemo.Api.Application.Features.Queries.GetVisitDetailById;

public class GetVisitDetailByIdQueryHandler : IRequestHandler<GetVisitDetailByIdQuery, VisitDetail>
{
    private readonly IMapper _mapper;
    private readonly IVisitRepository _visitRepository;

    public GetVisitDetailByIdQueryHandler(IMapper mapper, IVisitRepository visitRepository)
    {
        _mapper = mapper;
        _visitRepository = visitRepository;
    }

    public async Task<VisitDetail> Handle(GetVisitDetailByIdQuery request, CancellationToken cancellationToken)
    {
        var visit = await _visitRepository.GetAsync(v => v.Id == request.VisitId, i => i.VisitParts);

        var result = _mapper.Map<VisitDetail>(visit);

        return result;
    }
}
