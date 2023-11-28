namespace WorkOrderDemo.Api.Domain.SeedWork;

public interface IRepository<T> where T : BaseEntity, new()
{
    IUnitOfWork UnitOfWork { get; }
}
