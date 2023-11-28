using WorkOrderDemo.Api.Domain.SeedWork.Paging;
using System.Linq.Expressions;
using WorkOrderDemo.Api.Domain.SeedWork;

namespace WorkOrderDemo.Api.Application.Interfaces.Repositories;

public interface IGenericRepository<T> : IRepository<T> where T : BaseEntity, new()
{
    Task<T?> GetAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes);

    Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? predicate = null,
                                      Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
                                      params Expression<Func<T, object>>[] includes);


    Task<IPaginate<T>> GetAllAsPaginateAsync(int index = 0, int size = 10, Expression<Func<T, bool>>? predicate = null,
                                    Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
                                    params Expression<Func<T, object>>[] includes);

    Task<T> AddAsync(T entity);
    T Update(T entity);
    T Delete(T entity);
}

