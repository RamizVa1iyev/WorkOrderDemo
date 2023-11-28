using BlazorBootstrap;
using System.Net.Http.Json;
using WorkOrderDemo.WebApp.Models;
using WorkOrderDemo.WebApp.Models.Visit;
using WorkOrderDemo.WebApp.Services.Interfaces;

namespace WorkOrderDemo.WebApp.Services;

public class VisitService : IVisitService
{
    private readonly HttpClient _httpClient;

    public VisitService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<VisitDetail?> AddAsync(VisitDetail visitDetail, List<ToastMessage> messages)
    {
        var result = await _httpClient.PostAsJsonAsync($"Visits", visitDetail);

        if (result.IsSuccessStatusCode)
        {
            messages.Add(new ToastMessage(ToastType.Success, "Selected Record Successfully Created!"));
            return await result.Content.ReadFromJsonAsync<VisitDetail>();
        }

        var error = await result.Content.ReadFromJsonAsync<ErrorResponse>();
        messages.Add(new ToastMessage(ToastType.Danger, error.Title, error.Detail));

        return default;
    }

    public async Task DeleteAsync(Guid? id)
    {
        await _httpClient.DeleteAsync($"Visits/{id}");
    }

    public async Task<List<VisitDetail>?> GetAll(Guid workOrderId)
    {
        var result = await _httpClient.GetFromJsonAsync<Paginate<VisitDetail>>($"Visits?index={0}&size={10}&workOrderId={workOrderId}");

        return result?.Items;
    }

    public async Task<VisitDetail> GetByIdAsync(Guid id)
    {
        var result = await _httpClient.GetFromJsonAsync<VisitDetail>($"Visits/{id}");

        return result;
    }

    public async Task<VisitDetail?> UpdateAsync(VisitDetail visitDetail, List<ToastMessage> messages)
    {
        var result = await _httpClient.PutAsJsonAsync($"Visits/{visitDetail.Id}", visitDetail);

        if (result.IsSuccessStatusCode)
        {
            messages.Add(new ToastMessage(ToastType.Success, "Selected Record Successfully Updated!"));
            return await result.Content.ReadFromJsonAsync<VisitDetail>();
        }

        var error = await result.Content.ReadFromJsonAsync<ErrorResponse>();
        messages.Add(new ToastMessage(ToastType.Danger, error.Title, error.Detail));

        return default;
    }
}
