using MediatR;
using WorkOrderDemo.Api.Application.Features.Queries.ViewModels;
using WorkOrderDemo.Api.Domain.SeedWork.Paging;

namespace WorkOrderDemo.Api.Application.Features.Queries.GetVisitDetails;

public class GetVisitDetailsQuery:IRequest<IPaginate<VisitDetail>>
{
    public GetVisitDetailsQuery(int index, int size, Guid? workOrderId)
    {
        Index = index;
        Size = size;
        WorkOrderId = workOrderId;
    }

    public int Index { get; set; }

    public int Size { get; set; }

    public Guid? WorkOrderId { get; set; }
}
