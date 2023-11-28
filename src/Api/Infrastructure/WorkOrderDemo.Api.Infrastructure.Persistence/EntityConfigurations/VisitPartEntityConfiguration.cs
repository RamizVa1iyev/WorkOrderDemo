using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WorkOrderDemo.Api.Domain.AggregateModels.VisitAggregate;
using WorkOrderDemo.Api.Infrastructure.Persistence.Context;

namespace WorkOrderDemo.Api.Infrastructure.Persistence.EntityConfigurations;

public class VisitPartEntityConfiguration : IEntityTypeConfiguration<VisitPart>
{
    public void Configure(EntityTypeBuilder<VisitPart> builder)
    {
        builder.ToTable(nameof(VisitPart), WorkOrderDbContext.DEFAULT_SCHEMA);

        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id)
            .ValueGeneratedOnAdd();

        builder.Property(p => p.Name)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(p => p.Price)
            .HasPrecision(18, 2);
    }
}
