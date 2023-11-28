using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WorkOrderDemo.Api.Domain.AggregateModels.WorkOrderAggregate;
using WorkOrderDemo.Api.Infrastructure.Persistence.Context;

namespace WorkOrderDemo.Api.Infrastructure.Persistence.EntityConfigurations;

public class WorkOrderStatusEntityConfiguration : IEntityTypeConfiguration<WorkOrderStatus>
{
    public void Configure(EntityTypeBuilder<WorkOrderStatus> builder)
    {
        builder.ToTable(nameof(WorkOrderStatus), WorkOrderDbContext.DEFAULT_SCHEMA);

        builder.HasKey(s => s.Id);

        builder.Property(s => s.Id)
            .ValueGeneratedNever()
            .IsRequired();

        builder.Property(s => s.Name)
           .HasMaxLength(200)
           .IsRequired();
    }
}
