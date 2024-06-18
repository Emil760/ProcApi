using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProcApi.Domain.Entities;

namespace ProcApi.Infrastructure.ModelConfigurations;

public class AnnualProcurementConfiguration : IEntityTypeConfiguration<AnnualProcurement>
{
    public void Configure(EntityTypeBuilder<AnnualProcurement> builder)
    {
        builder.Property(ap => ap.Name)
            .HasColumnType("varchar")
            .HasMaxLength(300);

        builder.Property(ap => ap.Description)
            .HasColumnType("varchar")
            .HasMaxLength(300);

        builder.Property(ap => ap.CreationDate)
            .HasColumnType("date")
            .HasDefaultValue(DateTime.Now);

        builder.Property(ap => ap.Version)
            .HasColumnType("smallint")
            .HasDefaultValue(1);

        builder.HasMany(ap => ap.Items)
            .WithOne(api => api.AnnualProcurement)
            .HasForeignKey(api => api.AnnualProcurementId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}