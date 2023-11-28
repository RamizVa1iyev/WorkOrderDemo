using WorkOrderDemo.Api.Domain.AggregateModels.VisitAggregate;

namespace WorkOrderDemo.Api.Application.Interfaces.Repositories;

public interface IVisitRepository:IGenericRepository<Visit>
{
    Task<Visit> UpdateWithPartsAsync(Visit visit);
}
