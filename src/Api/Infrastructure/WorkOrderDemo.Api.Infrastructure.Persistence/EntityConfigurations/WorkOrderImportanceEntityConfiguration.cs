using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WorkOrderDemo.Api.Domain.AggregateModels.WorkOrderAggregate;
using WorkOrderDemo.Api.Infrastructure.Persistence.Context;

namespace WorkOrderDemo.Api.Infrastructure.Persistence.EntityConfigurations;

public class WorkOrderImportanceEntityConfiguration : IEntityTypeConfiguration<WorkOrderImportance>
{
    public void Configure(EntityTypeBuilder<WorkOrderImportance> builder)
    {
        builder.ToTable(nameof(WorkOrderImportance), WorkOrderDbContext.DEFAULT_SCHEMA);

        builder.HasKey(i => i.Id);

        builder.Property(i => i.Id)
            .ValueGeneratedNever()
            .IsRequired();

        builder.Property(i => i.Name)
           .HasMaxLength(200)
           .IsRequired();
    }
}
