using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WorkOrderDemo.Api.Application.Interfaces.Repositories;
using WorkOrderDemo.Api.Infrastructure.Persistence.Context;
using WorkOrderDemo.Api.Infrastructure.Persistence.Repositories;

namespace WorkOrderDemo.Api.Infrastructure.Persistence;

public static class ServiceRegistration
{
    public static IServiceCollection AddPersistenceRegistration(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<WorkOrderDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("WorkOrderConnectionString"));
        });

        services.AddScoped<IWorkOrderRepository, WorkOrderRepository>();
        services.AddScoped<IVisitRepository, VisitRepository>();

        return services;
    }
}
