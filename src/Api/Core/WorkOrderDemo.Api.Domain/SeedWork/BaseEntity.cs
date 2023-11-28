
namespace WorkOrderDemo.Api.Domain.SeedWork;

public abstract class BaseEntity
{
    public virtual Guid Id { get; protected set; }

    public DateTime CreateDate { get; set; } = DateTime.Now;
}
