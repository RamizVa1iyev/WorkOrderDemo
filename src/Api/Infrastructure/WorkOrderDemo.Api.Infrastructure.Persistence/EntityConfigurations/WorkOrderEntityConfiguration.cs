using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WorkOrderDemo.Api.Domain.AggregateModels.WorkOrderAggregate;
using WorkOrderDemo.Api.Infrastructure.Persistence.Context;

namespace WorkOrderDemo.Api.Infrastructure.Persistence.EntityConfigurations;

public class WorkOrderEntityConfiguration : IEntityTypeConfiguration<WorkOrder>
{
    public void Configure(EntityTypeBuilder<WorkOrder> builder)
    {
        builder.ToTable(nameof(WorkOrder), WorkOrderDbContext.DEFAULT_SCHEMA);

        builder.HasKey(w => w.Id);
        builder.Property(w => w.Id).ValueGeneratedOnAdd();

        builder
            .Property<int>("orderImportanceId")
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasColumnName("OrderImportanceId")
            .IsRequired();

        builder
            .Property<int>("orderStatusId")
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasColumnName("OrderStatusId")
            .IsRequired();

        builder.Property(w => w.OrderingCompanyName)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(w => w.Description)
            .HasMaxLength(1000)
            .IsRequired();

        var navigation = builder.Metadata.FindNavigation(nameof(WorkOrder.Visits));
        navigation?.SetPropertyAccessMode(PropertyAccessMode.Field);

        builder.HasOne(w => w.OrderImportance)
            .WithMany()
            .HasForeignKey("orderImportanceId");

        builder.HasOne(w => w.OrderStatus)
            .WithMany()
            .HasForeignKey("orderStatusId");
    }
}
