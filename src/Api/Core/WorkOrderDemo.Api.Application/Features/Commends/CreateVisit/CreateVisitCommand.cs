using MediatR;
using WorkOrderDemo.Api.Application.Features.Queries.ViewModels;

namespace WorkOrderDemo.Api.Application.Features.Commends.CreateVisit;

public class CreateVisitCommand : IRequest<VisitDetail>
{
    public Guid WorkOrderId { get; init; }

    public string VisitorName { get; init; }

    public DateTime VisitDate { get; init; }

    public ICollection<VisitPartDto> VisitParts { get; init; }

    public CreateVisitCommand(Guid workOrderId, string visitorName, DateTime visitDate, List<VisitPartDto> visitParts)
    {
        WorkOrderId = workOrderId;
        VisitorName = visitorName;
        VisitDate = visitDate;
        VisitParts = visitParts;
    }

    public CreateVisitCommand()
    {
        VisitParts = new List<VisitPartDto>();
    }
}


public class VisitPartDto
{
    public string Name { get; init; }

    public int Quantity { get; init; }

    public decimal Price { get; init; }
}