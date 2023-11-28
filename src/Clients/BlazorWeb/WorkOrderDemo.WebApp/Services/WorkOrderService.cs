using BlazorBootstrap;
using System.Net.Http.Json;
using WorkOrderDemo.WebApp.Models;
using WorkOrderDemo.WebApp.Models.WorkOrder;
using WorkOrderDemo.WebApp.Services.Interfaces;

namespace WorkOrderDemo.WebApp.Services;

public class WorkOrderService : IWorkOrderService
{
    private readonly HttpClient _httpClient;

    public WorkOrderService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task DeleteAsync(Guid? id)
    {
        await _httpClient.DeleteAsync($"WorkOrders/{id}");
    }

    public async Task<Paginate<WorkOrderDetail>> GetAll(int index, int size)
    {
        var result = await _httpClient.GetFromJsonAsync<Paginate<WorkOrderDetail>>($"WorkOrders?index={index}&size={size}");

        return result;
    }

    public async Task<WorkOrderDetail> GetByIdAsync(Guid id)
    {
        var result = await _httpClient.GetFromJsonAsync<WorkOrderDetail>($"WorkOrders/{id}");

        return result;
    }

    public async Task<List<WorkOrderImportance>> GetImportances()
    {
        var result = await _httpClient.GetFromJsonAsync<List<WorkOrderImportance>>($"WorkOrderImportances");

        return result;
    }

    public async Task<List<WorkOrderStatus>> GetStatus()
    {
        var result = await _httpClient.GetFromJsonAsync<List<WorkOrderStatus>>($"WorkOrderStatus");

        return result;
    }

    public async Task<WorkOrderDetail?> UpdateAsync(WorkOrderDetail workOrderDetail, List<ToastMessage> messages)
    {
        var result = await _httpClient.PutAsJsonAsync($"WorkOrders/{workOrderDetail.Id}", workOrderDetail);

        if (result.IsSuccessStatusCode)
        {
            messages.Add(new ToastMessage(ToastType.Success, "Successfully Updated!"));
            return await result.Content.ReadFromJsonAsync<WorkOrderDetail>();
        }

        var error = await result.Content.ReadFromJsonAsync<ErrorResponse>();
        messages.Add(new ToastMessage(ToastType.Danger, error.Title, error.Detail));

        return default;
    }

    public async Task<WorkOrderDetail?> AddAsync(WorkOrderDetail workOrderDetail, List<ToastMessage> messages)
    {
        var result = await _httpClient.PostAsJsonAsync($"WorkOrders", workOrderDetail);

        if (result.IsSuccessStatusCode)
        {
            messages.Add(new ToastMessage(ToastType.Success, "Successfully Created!"));
            return await result.Content.ReadFromJsonAsync<WorkOrderDetail>();
        }

        var error = await result.Content.ReadFromJsonAsync<ErrorResponse>();
        messages.Add(new ToastMessage(ToastType.Danger, error.Title, error.Detail));

        return default;
    }

    public async Task<ChangingDataInformation> ChangeDatasRandomly()
    {
        var result = await _httpClient.GetFromJsonAsync<ChangingDataInformation>($"WorkOrders/ChangeDatasRandomly");

        return result;
    }
}
