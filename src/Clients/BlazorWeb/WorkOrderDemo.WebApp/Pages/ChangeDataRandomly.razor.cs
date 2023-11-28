using Microsoft.AspNetCore.Components;
using WorkOrderDemo.WebApp.Models.WorkOrder;
using WorkOrderDemo.WebApp.Services.Interfaces;

namespace WorkOrderDemo.WebApp.Pages;

public partial class ChangeDataRandomly
{
    [Inject]
    public IWorkOrderService WorkOrderService { get; set; }

    public ChangingDataInformation ChangingDataInformation { get; set; }


    public async Task ChangeData()
    {
        ChangingDataInformation = await WorkOrderService.ChangeDatasRandomly();
    }
}
