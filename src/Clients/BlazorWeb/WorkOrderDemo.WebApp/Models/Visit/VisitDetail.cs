namespace WorkOrderDemo.WebApp.Models.Visit;

public class VisitDetail
{
    public VisitDetail(Guid? id, Guid workOrderId, string visitorName, DateTime visitDate, List<VisitPartDetail> visitParts)
    {
        Id = id;
        WorkOrderId = workOrderId;
        VisitorName = visitorName;
        VisitDate = visitDate;
        VisitParts = visitParts;
    }

    public VisitDetail()
    {
        VisitParts=new List<VisitPartDetail>();
    }

    public Guid? Id { get; set; }

    public Guid WorkOrderId { get; set; }

    public string VisitorName { get; set; }

    public DateTime VisitDate { get; set; }

    public decimal TotalPrice => VisitParts.Sum(p => p.Quantity * p.Price);

    public List<VisitPartDetail> VisitParts { get; set; }
}




public class VisitPartDetail
{
    public VisitPartDetail(Guid? id, string name, int quantity, decimal price)
    {
        Id = id;
        Name = name;
        Quantity = quantity;
        Price = price;
    }

    public VisitPartDetail()
    {
        
    }

    public Guid? Id { get; set; }

    public string Name { get; set; }

    public int Quantity { get; set; }

    public decimal Price { get; set; }
}
