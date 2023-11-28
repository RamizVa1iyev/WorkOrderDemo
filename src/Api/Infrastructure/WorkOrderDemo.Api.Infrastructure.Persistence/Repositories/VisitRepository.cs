using Microsoft.EntityFrameworkCore;
using System;
using WorkOrderDemo.Api.Application.Interfaces.Repositories;
using WorkOrderDemo.Api.Domain.AggregateModels.VisitAggregate;
using WorkOrderDemo.Api.Domain.Exceptions;
using WorkOrderDemo.Api.Infrastructure.Persistence.Context;

namespace WorkOrderDemo.Api.Infrastructure.Persistence.Repositories;

public class VisitRepository : GenericRepository<Visit>, IVisitRepository
{
    public VisitRepository(WorkOrderDbContext workOrderDbContext) : base(workOrderDbContext)
    {
    }

    public override Task<Visit> AddAsync(Visit entity)
    {
        if (base._workOrderDbContext.Visits.Count(v => v.WorkOrderId == entity.WorkOrderId) >= 3)
            throw new VisitException("Visit count cannot be more than 3");


        return base.AddAsync(entity);
    }

    public async Task<Visit> UpdateWithPartsAsync(Visit visit)
    {
        var existingEntities = await _workOrderDbContext.Set<VisitPart>().Where(v => v.VisitId == visit.Id).AsQueryable()
                                                                         .AsNoTracking().ToListAsync();

        var dbSetEntity = _workOrderDbContext.Set<VisitPart>();


        var entitiesToRemove = existingEntities.Where(e => !visit.VisitParts.Any(p => p.Id == e.Id)).ToList();
        dbSetEntity.RemoveRange(entitiesToRemove);

        foreach (var entity in visit.VisitParts)
        {
            var updatedEntity = existingEntities.FirstOrDefault(e => e.Id == entity.Id);
            if (updatedEntity == null)
            {
                await dbSetEntity.AddAsync(entity);
            }
            else
            {
                dbSetEntity.Update(entity);
            }
        }

        _workOrderDbContext.Set<Visit>().Update(visit);

        await _workOrderDbContext.SaveChangesAsync();

        return visit;
    }
}
