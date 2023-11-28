using WorkOrderDemo.Api.Domain.AggregateModels.WorkOrderAggregate;
using WorkOrderDemo.Api.Domain.Exceptions;
using WorkOrderDemo.Api.Domain.SeedWork;

namespace WorkOrderDemo.Api.Domain.AggregateModels.VisitAggregate;

public class Visit : BaseEntity, IAggregateRoot
{
    public Visit()
    {
        _visitParts = new List<VisitPart>();
    }

    public Visit(Guid id) : this()
    {
        Id = id;
    }

    public Visit(Guid id, Guid workOrderId, string visitorName, DateTime visitDate) : this(id)
    {
        VisitException.ThrowIfNullOrEmpty(visitorName, nameof(visitorName));
        VisitException.ThrowIfDefault(visitDate, nameof(visitDate));

        SetWorkOrderId(workOrderId);

        VisitorName = visitorName;
        VisitDate = visitDate;
    }

    public Visit(Guid workOrderId, string visitorName, DateTime visitDate) : this(Guid.NewGuid(), workOrderId, visitorName, visitDate)
    {

    }

    public Guid WorkOrderId { get; private set; }

    public WorkOrder WorkOrder { get; private set; }

    public string VisitorName { get; private set; }

    public DateTime VisitDate { get; private set; }


    private readonly List<VisitPart> _visitParts;

    public IReadOnlyCollection<VisitPart> VisitParts => _visitParts;

    public void AddVisitPart(string name, int quantity, decimal price)
    {
        AddVisitPart(Guid.NewGuid(), name, quantity, price);
    }

    public void AddVisitPart(VisitPart visitPart)
    {
        if (_visitParts.Count >= 5)
            throw new VisitException("Maximum count of Visit parts is 5");

        _visitParts.Add(visitPart);
    }

    public void AddVisitPart(Guid id, string name, int quantity, decimal price)
    {
        if (_visitParts.Count >= 5)
            throw new VisitException("Maximum count of Visit parts is 5");

        var visitPart = new VisitPart(id, this.Id, name, quantity, price);
        _visitParts.Add(visitPart);
    }

    public void SetWorkOrderId(Guid workOrderId)
    {
        if (workOrderId == Guid.Empty)
            throw new WorkOrderException(nameof(workOrderId));

        WorkOrderId = workOrderId;
    }
}
