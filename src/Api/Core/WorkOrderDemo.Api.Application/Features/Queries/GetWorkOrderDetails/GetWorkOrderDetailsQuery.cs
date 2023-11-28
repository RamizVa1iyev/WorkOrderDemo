using MediatR;
using WorkOrderDemo.Api.Application.Features.Queries.ViewModels;
using WorkOrderDemo.Api.Domain.SeedWork.Paging;

namespace WorkOrderDemo.Api.Application.Features.Queries.GetWorkOrderDetails;

public class GetWorkOrderDetailsQuery : IRequest<IPaginate<WorkOrderDetail>>
{
    public GetWorkOrderDetailsQuery(int index, int size)
    {
        Index = index;
        Size = size;
    }

    public int Index { get; set; }

    public int Size { get; set; }
}
