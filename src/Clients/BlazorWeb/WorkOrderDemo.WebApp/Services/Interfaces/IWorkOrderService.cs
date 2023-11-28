using BlazorBootstrap;
using WorkOrderDemo.WebApp.Models;
using WorkOrderDemo.WebApp.Models.WorkOrder;

namespace WorkOrderDemo.WebApp.Services.Interfaces;

public interface IWorkOrderService
{
    Task DeleteAsync(Guid? id);
    Task<Paginate<WorkOrderDetail>> GetAll(int index, int size);
    Task<WorkOrderDetail> GetByIdAsync(Guid id);
    Task<List<WorkOrderStatus>> GetStatus();
    Task<List<WorkOrderImportance>> GetImportances();
    Task<WorkOrderDetail> UpdateAsync(WorkOrderDetail workOrderDetail, List<ToastMessage> messages);
    Task<WorkOrderDetail> AddAsync(WorkOrderDetail workOrderDetail, List<ToastMessage> messages);
    Task<ChangingDataInformation> ChangeDatasRandomly();
}
