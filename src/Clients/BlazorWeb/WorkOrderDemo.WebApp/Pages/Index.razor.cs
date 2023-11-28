using BlazorBootstrap;
using Microsoft.AspNetCore.Components;
using WorkOrderDemo.WebApp.Models;
using WorkOrderDemo.WebApp.Models.WorkOrder;
using WorkOrderDemo.WebApp.Services.Interfaces;

namespace WorkOrderDemo.WebApp.Pages
{
    public partial class Index
    {
        Grid<WorkOrderDetail> grid;

        public int PageIndex { get; set; } = 0;
        public int Size { get; set; } = 10;

        [Inject]
        public IWorkOrderService WorkOrderService { get; set; }

        private async Task<GridDataProviderResult<WorkOrderDetail>> WorkOrdersDataProvider(GridDataProviderRequest<WorkOrderDetail> request)
        {
            var workOrders = await WorkOrderService.GetAll(request.PageNumber - 1, request.PageSize);

            return await Task.FromResult(new GridDataProviderResult<WorkOrderDetail>() { Data = workOrders.Items, TotalCount = workOrders.Count });
        }

        private async Task DeleteWorkOrder(Guid? id)
        {
            await WorkOrderService.DeleteAsync(id);

            await grid.RefreshDataAsync();
        }
    }
}
