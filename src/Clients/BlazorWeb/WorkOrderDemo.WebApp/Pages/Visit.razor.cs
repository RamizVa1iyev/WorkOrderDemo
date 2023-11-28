using BlazorBootstrap;
using Microsoft.AspNetCore.Components;
using WorkOrderDemo.WebApp.Models.Visit;
using WorkOrderDemo.WebApp.Services.Interfaces;

namespace WorkOrderDemo.WebApp.Pages;

public partial class Visit
{
    List<ToastMessage> messages = new List<ToastMessage>();

    Grid<VisitDetail> grid;


    [Parameter]
    public string Id { get; set; }

    public List<VisitDetail> VisitDetails { get; set; }

    public VisitDetail SelectedVisitDetail { get; set; }

    public List<VisitPartDetail> SelectedVisitParts { get; set; } = new List<VisitPartDetail>();

    [Inject]
    public IVisitService VisitService { get; set; }

    private async Task<GridDataProviderResult<VisitDetail>> VisitsDataProvider(GridDataProviderRequest<VisitDetail> request)
    {
        VisitDetails ??= await VisitService.GetAll(Guid.Parse(Id));
        return await Task.FromResult(request.ApplyTo(VisitDetails));
    }

    private async Task DeleteVisit(Guid? id)
    {
        await VisitService.DeleteAsync(id);
        VisitDetails = null;
        await grid.RefreshDataAsync();
    }

    private Task OnSelectedItemsChanged(HashSet<VisitDetail> visitDetail)
    {
        SelectedVisitDetail = visitDetail?.FirstOrDefault();
        SelectedVisitParts = SelectedVisitDetail?.VisitParts ?? new List<VisitPartDetail>();
        return Task.CompletedTask;
    }

    private async Task Save()
    {
        if (SelectedVisitDetail == null)
        {
            messages.Add(new ToastMessage(ToastType.Danger, "Select Visit Record"));
            return;
        }

        VisitDetail result;
        if (SelectedVisitDetail.Id == default)
        {
            result = await VisitService.AddAsync(SelectedVisitDetail, messages);
        }
        else
        {
            result = await VisitService.UpdateAsync(SelectedVisitDetail, messages);
        }

        if (result != null)
        {
            SelectedVisitDetail = result;
        }
    }

    private async Task AddVisitRow()
    {
        if (VisitDetails.Count >= 3)
        {
            messages.Add(new ToastMessage(ToastType.Danger, "Maximum visit count is 3"));
            return;
        }

        VisitDetails.Add(new VisitDetail() { WorkOrderId = Guid.Parse(Id) });
        await grid.RefreshDataAsync();
    }
}
