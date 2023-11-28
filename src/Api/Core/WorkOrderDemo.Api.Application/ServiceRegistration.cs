using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace WorkOrderDemo.Api.Application;

public static class ServiceRegistration
{
    public static IServiceCollection AddApplicationRegistration(this IServiceCollection services)
    {
        var assembly = Assembly.GetExecutingAssembly();

        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly));
        services.AddAutoMapper(assembly);

        return services;
    }
}
