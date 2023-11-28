using WorkOrderDemo.Api.Domain.Exceptions;
using WorkOrderDemo.Api.Domain.SeedWork;

namespace WorkOrderDemo.Api.Domain.AggregateModels.VisitAggregate;

public class VisitPart : BaseEntity
{
    public VisitPart(Guid id, Guid visitId, string name, int quantity, decimal price)
    {
        VisitException.ThrowIfNullOrEmpty(name, nameof(name));

        if (quantity <= 0)
            throw new VisitException("Quantity cannot be less than or equals to zero");

        if (price < 0)
            throw new VisitException("Price cannot be less than zero");


        Id = id;
        VisitId = visitId;
        Name = name;
        Quantity = quantity;
        Price = price;
    }

    public VisitPart(Guid visitId, string name, int quantity, decimal price) : this(Guid.NewGuid(), visitId, name, quantity, price)
    {

    }

    public Guid VisitId { get; set; }

    public string Name { get; private set; }

    public int Quantity { get; private set; }

    public decimal Price { get; private set; }

    public void SetQuantity(int quantity) => Quantity = quantity;

    public void SetPrice(decimal price) => Price = price;

}
