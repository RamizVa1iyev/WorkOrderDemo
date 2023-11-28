using AutoMapper;
using WorkOrderDemo.Api.Application.Features.Queries.ViewModels;
using WorkOrderDemo.Api.Domain.AggregateModels.VisitAggregate;
using WorkOrderDemo.Api.Domain.SeedWork.Paging;

namespace WorkOrderDemo.Api.Application.Mapping;

public class VisitProfile : Profile
{
    public VisitProfile()
    {
        CreateMap<Visit, VisitDetail>();
        CreateMap<VisitPart, VisitPartDetail>();
        CreateMap<IPaginate<Visit>, Paginate<VisitDetail>>();
    }
}
