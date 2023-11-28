using Microsoft.EntityFrameworkCore;
using WorkOrderDemo.Api.Domain.AggregateModels.VisitAggregate;
using WorkOrderDemo.Api.Domain.AggregateModels.WorkOrderAggregate;
using WorkOrderDemo.Api.Domain.SeedWork;
using WorkOrderDemo.Api.Infrastructure.Persistence.EntityConfigurations;

namespace WorkOrderDemo.Api.Infrastructure.Persistence.Context;

public class WorkOrderDbContext : DbContext, IUnitOfWork
{
    public WorkOrderDbContext()
    {

    }

    public WorkOrderDbContext(DbContextOptions<WorkOrderDbContext> options) : base(options)
    {

    }

    public const string DEFAULT_SCHEMA = "ordering";

    public DbSet<WorkOrder> WorkOrders { get; set; }

    public DbSet<Visit> Visits { get; set; }

    public DbSet<VisitPart> VisitParts { get; set; }

    public DbSet<WorkOrderStatus> WorkOrderStatus { get; set; }

    public DbSet<WorkOrderImportance> WorkOrderImportances { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new WorkOrderEntityConfiguration());
        modelBuilder.ApplyConfiguration(new WorkOrderStatusEntityConfiguration());
        modelBuilder.ApplyConfiguration(new WorkOrderImportanceEntityConfiguration());
        modelBuilder.ApplyConfiguration(new VisitPartEntityConfiguration());
        modelBuilder.ApplyConfiguration(new VisitEntityConfiguration());
    }
}
