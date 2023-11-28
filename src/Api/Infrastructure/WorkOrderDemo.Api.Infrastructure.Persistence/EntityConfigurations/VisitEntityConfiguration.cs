using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WorkOrderDemo.Api.Domain.AggregateModels.VisitAggregate;
using WorkOrderDemo.Api.Infrastructure.Persistence.Context;

namespace WorkOrderDemo.Api.Infrastructure.Persistence.EntityConfigurations;

public class VisitEntityConfiguration : IEntityTypeConfiguration<Visit>
{
    public void Configure(EntityTypeBuilder<Visit> builder)
    {
        builder.ToTable(nameof(Visit), WorkOrderDbContext.DEFAULT_SCHEMA);

        builder.HasKey(v => v.Id);
        builder.Property(v => v.Id)
            .ValueGeneratedOnAdd();

        builder.Property(v => v.VisitorName)
            .HasMaxLength(200)
            .IsRequired();

        var navigation = builder.Metadata.FindNavigation(nameof(Visit.VisitParts));
        navigation?.SetPropertyAccessMode(PropertyAccessMode.Field);

        builder.HasOne(v => v.WorkOrder)
               .WithMany(w => w.Visits)
               .HasForeignKey(v => v.WorkOrderId);

        builder.HasMany(v => v.VisitParts)
               .WithOne()
               .HasForeignKey("VisitId");
    }
}
