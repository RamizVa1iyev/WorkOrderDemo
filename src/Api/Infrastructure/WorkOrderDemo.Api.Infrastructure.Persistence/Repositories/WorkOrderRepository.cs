using Microsoft.EntityFrameworkCore;
using Polly;
using System.Linq.Expressions;
using WorkOrderDemo.Api.Application.Features.Queries.ViewModels;
using WorkOrderDemo.Api.Application.Interfaces.Repositories;
using WorkOrderDemo.Api.Domain.AggregateModels.WorkOrderAggregate;
using WorkOrderDemo.Api.Domain.SeedWork.Paging;
using WorkOrderDemo.Api.Infrastructure.Persistence.Context;

namespace WorkOrderDemo.Api.Infrastructure.Persistence.Repositories;

public class WorkOrderRepository : GenericRepository<WorkOrder>, IWorkOrderRepository
{
    public WorkOrderRepository(WorkOrderDbContext workOrderDbContext) : base(workOrderDbContext)
    {
    }

    public async Task<ChangingDataInformation> ChangeDatasRandomlyAsync()
    {
        ChangingDataInformation result = new ChangingDataInformation();
        Random random = new Random();

        var randomWorkOrders = _workOrderDbContext.WorkOrders.OrderBy(r => Guid.NewGuid()).Take(5).ToList();
        result.DeletedWorkOrdersMessages = new List<string>();
        foreach (var workOrder in randomWorkOrders)
        {
            result.DeletedWorkOrdersMessages.Add($"Deleted Work Order: Id = {workOrder.Id}, description = {workOrder.Description}, deadline = {workOrder.Deadline.ToShortDateString()}");

            _workOrderDbContext.WorkOrders.Remove(workOrder);
        }


        var randomVisits = _workOrderDbContext.Visits.OrderBy(r => Guid.NewGuid()).Take(5).ToList();
        result.DeletedVisitsMessages = new List<string>();
        foreach (var visit in randomVisits)
        {
            result.DeletedVisitsMessages.Add($"Deleted Visit: Id = {visit.Id}, visitorName = {visit.VisitorName}, visitDate = {visit.VisitDate.ToShortDateString()}");

            _workOrderDbContext.Visits.Remove(visit);
        }

        var randomVisitParts = _workOrderDbContext.VisitParts.OrderBy(r => Guid.NewGuid()).Take(5).ToList();
        result.DeletedPartsMessages = new List<string>();
        foreach (var visitPart in randomVisitParts)
        {
            result.DeletedPartsMessages.Add($"Deleted visit part: Id = {visitPart.Id}, name = {visitPart.Name}, quantity = {visitPart.Quantity}, price = {visitPart.Price}");

            _workOrderDbContext.VisitParts.Remove(visitPart);
        }

        var randomVisitPartsForQuantityChange = _workOrderDbContext.VisitParts.OrderBy(r => Guid.NewGuid()).Take(5).ToList();
        result.ChangedQuantitiesMessages = new List<string>();
        foreach (var visitPart in randomVisitPartsForQuantityChange)
        {
            int newQuantity = random.Next(1, 21);
            result.ChangedQuantitiesMessages.Add($"Updated visit part: Id = {visitPart.Id}, name = {visitPart.Name}, price = {visitPart.Price}. Quantity updated from {visitPart.Quantity} to {newQuantity}");

            visitPart.SetQuantity(newQuantity);

            _workOrderDbContext.VisitParts.Update(visitPart);
        }


        var randomVisitPartsForPriceChange = _workOrderDbContext.VisitParts.OrderBy(r => Guid.NewGuid()).Take(5).ToList();
        result.ChangedPricesMessages = new List<string>();
        foreach (var visitPart in randomVisitPartsForPriceChange)
        {
            decimal newPrice = random.Next(1, 100);
            result.ChangedPricesMessages.Add($"Updated visit part: Id = {visitPart.Id}, name = {visitPart.Name}, quantity = {visitPart.Quantity}. Price updated from {visitPart.Price} to {newPrice}");

            visitPart.SetPrice(newPrice);

            _workOrderDbContext.VisitParts.Update(visitPart);
        }

        await _workOrderDbContext.SaveChangesAsync();

        return result;
    }

    public async Task<IPaginate<WorkOrderDetail>> GetDetailsWithCountAsync(int index, int size)
    {
        var query = base._workOrderDbContext.WorkOrders.OrderBy(o => o.Deadline).AsQueryable();

        var result = await query.Select(o =>
                                      new WorkOrderDetail(o.Id, o.OrderImportance.Name, o.OrderStatus.Name, o.OrderImportance.Id, o.OrderStatus.Id, o.Deadline,
                                                          o.OrderingCompanyName, o.Description, o.Visits.Count(),
                                                          o.Visits.SelectMany(v => v.VisitParts).Count())).ToPaginateAsync(index, size);

        return result;
    }

    public async Task<WorkOrderDetail> GetDetailWithCountAsync(Expression<Func<WorkOrder, bool>> predicate)
    {
        var query = base._workOrderDbContext.WorkOrders.AsQueryable();

        var result = await query.Where(predicate)
                                .Select(o => new WorkOrderDetail(o.Id, o.OrderImportance.Name, o.OrderStatus.Name, o.OrderImportance.Id, o.OrderStatus.Id, o.Deadline,
                                                                 o.OrderingCompanyName, o.Description, o.Visits.Count(),
                                                                 o.Visits.SelectMany(v => v.VisitParts).Count()))
                                .FirstOrDefaultAsync();

        return result;
    }
}
