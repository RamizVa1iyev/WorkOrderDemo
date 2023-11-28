using MediatR;
using System.Text.Json.Serialization;
using WorkOrderDemo.Api.Application.Features.Queries.ViewModels;

namespace WorkOrderDemo.Api.Application.Features.Commends.UpdateVisit;

public class UpdateVisitCommand : IRequest<VisitDetail>
{
    [JsonIgnore]
    public Guid Id { get; set; }

    public Guid WorkOrderId { get; init; }

    public string VisitorName { get; init; }

    public DateTime VisitDate { get; init; }

    public ICollection<UpdateVisitPartDto> VisitParts { get; set; }


    public UpdateVisitCommand(Guid workOrderId, string visitorName, DateTime visitDate, List<UpdateVisitPartDto> visitParts)
    {
        WorkOrderId = workOrderId;
        VisitorName = visitorName;
        VisitDate = visitDate;
        VisitParts = visitParts;
    }

    public UpdateVisitCommand()
    {
        VisitParts = new List<UpdateVisitPartDto>();
    }

}


public class UpdateVisitPartDto
{
    public Guid? Id { get; set; }

    public string Name { get; init; }

    public int Quantity { get; init; }

    public decimal Price { get; init; }
}
