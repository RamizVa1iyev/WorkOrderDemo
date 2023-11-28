using System.Linq.Expressions;
using WorkOrderDemo.Api.Application.Features.Queries.ViewModels;
using WorkOrderDemo.Api.Domain.AggregateModels.WorkOrderAggregate;
using WorkOrderDemo.Api.Domain.SeedWork.Paging;

namespace WorkOrderDemo.Api.Application.Interfaces.Repositories;

public interface IWorkOrderRepository:IGenericRepository<WorkOrder>
{
    Task<WorkOrderDetail> GetDetailWithCountAsync(Expression<Func<WorkOrder, bool>> predicate);
    Task<IPaginate<WorkOrderDetail>> GetDetailsWithCountAsync(int index,int size);
    Task<ChangingDataInformation> ChangeDatasRandomlyAsync();
}
