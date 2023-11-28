
namespace WorkOrderDemo.Api.Application.Features.Queries.ViewModels;

public class VisitDetail
{
    public Guid Id { get; init; }

    public Guid WorkOrderId { get; set; }

    public string VisitorName { get; init; }

    public DateTime VisitDate { get; init; }

    public decimal TotalPrice => VisitParts.Sum(p => p.Quantity * p.Price);

    public List<VisitPartDetail> VisitParts { get; set; }
}




public class VisitPartDetail
{
    public Guid Id { get; init; }

    public string Name { get; init; }

    public int Quantity { get; init; }

    public decimal Price { get; init; }
}
