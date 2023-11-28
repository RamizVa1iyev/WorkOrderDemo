using BlazorBootstrap;
using System.Collections.Generic;
using WorkOrderDemo.WebApp.Models;
using WorkOrderDemo.WebApp.Models.Visit;

namespace WorkOrderDemo.WebApp.Services.Interfaces;

public interface IVisitService
{
    Task DeleteAsync(Guid? id);
    Task<List<VisitDetail>> GetAll(Guid workOrderId);
    Task<VisitDetail> GetByIdAsync(Guid id);
    Task<VisitDetail> UpdateAsync(VisitDetail workOrderDetail, List<ToastMessage> messages);
    Task<VisitDetail> AddAsync(VisitDetail workOrderDetail, List<ToastMessage> messages);
}
