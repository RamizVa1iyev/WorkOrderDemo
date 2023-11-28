using AutoMapper;
using MediatR;
using WorkOrderDemo.Api.Application.Features.Queries.ViewModels;
using WorkOrderDemo.Api.Application.Interfaces.Repositories;
using WorkOrderDemo.Api.Domain.SeedWork.Paging;

namespace WorkOrderDemo.Api.Application.Features.Queries.GetVisitDetails;

public class GetVisitDetailsQueryHandler : IRequestHandler<GetVisitDetailsQuery, IPaginate<VisitDetail>>
{
    private readonly IMapper _mapper;

    private readonly IVisitRepository _visitRepository;

    public GetVisitDetailsQueryHandler(IMapper mapper, IVisitRepository visitRepository)
    {
        _mapper = mapper;
        _visitRepository = visitRepository;
    }

    public async Task<IPaginate<VisitDetail>> Handle(GetVisitDetailsQuery request, CancellationToken cancellationToken)
    {
        var visitDetails = await _visitRepository.GetAllAsPaginateAsync(request.Index, request.Size,
                                                                        predicate: request.WorkOrderId != null ? v => v.WorkOrderId == request.WorkOrderId : null,
                                                                        orderBy: v => v.OrderBy(o => o.VisitDate),
                                                                        includes: i => i.VisitParts);

        var result = _mapper.Map<Paginate<VisitDetail>>(visitDetails);

        return result;
    }
}
