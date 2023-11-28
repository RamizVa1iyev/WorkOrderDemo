using MediatR;
using WorkOrderDemo.Api.Application.Features.Queries.ViewModels;

namespace WorkOrderDemo.Api.Application.Features.Queries.GetVisitDetailById;

public class GetVisitDetailByIdQuery:IRequest<VisitDetail>
{
    public Guid VisitId { get; set; }

    public GetVisitDetailByIdQuery(Guid visitId)
    {
        VisitId = visitId;
    }
}
