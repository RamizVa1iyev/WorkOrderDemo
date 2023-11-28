using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WorkOrderDemo.Api.Application.Interfaces.Repositories;
using WorkOrderDemo.Api.Domain.SeedWork;
using WorkOrderDemo.Api.Domain.SeedWork.Paging;
using WorkOrderDemo.Api.Infrastructure.Persistence.Context;

namespace WorkOrderDemo.Api.Infrastructure.Persistence.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity, new()
{
    protected readonly WorkOrderDbContext _workOrderDbContext;

    public GenericRepository(WorkOrderDbContext workOrderDbContext)
    {
        _workOrderDbContext = workOrderDbContext;
    }

    public IUnitOfWork UnitOfWork => _workOrderDbContext;

    public virtual async Task<T> AddAsync(T entity)
    {
        await _workOrderDbContext.Set<T>().AddAsync(entity);

        return entity;
    }

    public virtual T Delete(T entity)
    {
        _workOrderDbContext.Set<T>().Remove(entity);

        return entity;
    }

    public virtual async Task<IPaginate<T>> GetAllAsPaginateAsync(int index = 0, int size = 10,
                                                    Expression<Func<T, bool>>? predicate = null,
                                                    Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
                                                    params Expression<Func<T, object>>[] includes)
    {
        IQueryable<T> query = _workOrderDbContext.Set<T>().AsQueryable();

        foreach (var include in includes)
        {
            query = query.Include(include);
        }

        if (predicate != null)
            query = query.Where(predicate);

        if (orderBy != null)
            return await orderBy(query).ToPaginateAsync(index, size);

        return await query.ToPaginateAsync(index, size);
    }

    public virtual async Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? predicate = null,
                                     Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
                                     params Expression<Func<T, object>>[] includes)
    {
        IQueryable<T> query = _workOrderDbContext.Set<T>().AsQueryable();

        foreach (var include in includes)
        {
            query = query.Include(include);
        }

        if (predicate != null)
            query = query.Where(predicate);

        if (orderBy != null)
            return await orderBy(query).ToListAsync();

        return await query.ToListAsync();
    }

    public virtual async Task<T?> GetAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes)
    {
        var query = _workOrderDbContext.Set<T>().AsQueryable();

        foreach (var include in includes)
        {
            query = query.Include(include);
        }

        return await query.FirstOrDefaultAsync(predicate);
    }

    public virtual T Update(T entity)
    {
        _workOrderDbContext.Set<T>().Update(entity);

        return entity;
    }
}



public static class IQueryablePaginateExtensions
{
    public static async Task<IPaginate<T>> ToPaginateAsync<T>(this IQueryable<T> source, int index, int size,
                                                              int from = 0,
                                                              CancellationToken cancellationToken = default)
    {
        if (from > index) throw new ArgumentException($"From: {from} > Index: {index}, must from <= Index");

        int count = await source.CountAsync(cancellationToken).ConfigureAwait(false);
        List<T> items = await source.Skip((index - from) * size).Take(size).ToListAsync(cancellationToken)
                                    .ConfigureAwait(false);
        Paginate<T> list = new()
        {
            Index = index,
            Size = size,
            From = from,
            Count = count,
            Items = items,
            Pages = (int)Math.Ceiling(count / (double)size)
        };

        return list;
    }
}