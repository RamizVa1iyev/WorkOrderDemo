using BlazorBootstrap;
using Microsoft.AspNetCore.Components;
using WorkOrderDemo.WebApp.Models.WorkOrder;
using WorkOrderDemo.WebApp.Services.Interfaces;

namespace WorkOrderDemo.WebApp.Pages;

public partial class SaveWorkOrder
{
    [Parameter]
    public string Id { get; set; }

    [Inject]
    public IWorkOrderService WorkOrderService { get; set; }

    List<ToastMessage> messages = new List<ToastMessage>();

    public WorkOrderDetail WorkOrderDetail { get; set; } = new WorkOrderDetail();

    public List<WorkOrderStatus> WorkOrderStatuses { get; set; } = new List<WorkOrderStatus>();

    public List<WorkOrderImportance> WorkOrderImportances { get; set; } = new List<WorkOrderImportance>();

    protected override async Task OnParametersSetAsync()
    {
        if (String.IsNullOrEmpty(Id))
            return;

        WorkOrderDetail = await WorkOrderService.GetByIdAsync(Guid.Parse(Id));
    }

    protected override async Task OnInitializedAsync()
    {
        WorkOrderImportances = await WorkOrderService.GetImportances();
        WorkOrderStatuses = await WorkOrderService.GetStatus();
    }

    private async Task Save()
    {
        WorkOrderDetail result;
        if (String.IsNullOrEmpty(Id))
        {
            result = await WorkOrderService.AddAsync(WorkOrderDetail, messages);
        }
        else
        {
            result = await WorkOrderService.UpdateAsync(WorkOrderDetail, messages);
        }

        if (result != null)
        {
            WorkOrderDetail = result;
        }
    }
}
