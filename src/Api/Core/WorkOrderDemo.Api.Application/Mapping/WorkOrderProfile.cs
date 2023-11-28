using AutoMapper;
using WorkOrderDemo.Api.Application.Features.Queries.ViewModels;
using WorkOrderDemo.Api.Domain.AggregateModels.WorkOrderAggregate;

namespace WorkOrderDemo.Api.Application.Mapping;

public class WorkOrderProfile : Profile
{
    public WorkOrderProfile()
    {
        CreateMap<WorkOrder, WorkOrderDetail>()
                                               .ForMember(d => d.OrderStatus, opt => opt.MapFrom(v => WorkOrderStatus.From(v.GetOrderStatusId()).Name))
                                               .ForMember(d => d.OrderImportance, opt => opt.MapFrom(v => WorkOrderImportance.From(v.GetOrderImportanceId()).Name))
                                               .ForMember(d => d.OrderStatusId, opt => opt.MapFrom(v => v.GetOrderStatusId()))
                                               .ForMember(d => d.OrderImportanceId, opt => opt.MapFrom(v => v.GetOrderImportanceId()));
    }
}
