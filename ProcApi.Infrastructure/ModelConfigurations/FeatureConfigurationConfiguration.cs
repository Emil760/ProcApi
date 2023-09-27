using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProcApi.Domain.Entities;

namespace ProcApi.Infrastructure.ModelConfigurations;

public class FeatureConfigurationConfiguration : IEntityTypeConfiguration<FeatureConfiguration>
{
    public void Configure(EntityTypeBuilder<FeatureConfiguration> builder)
    {
        builder.Property(fc => fc.Name)
            .HasColumnType("varchar")
            .HasMaxLength(300)
            .IsRequired();

        builder.Property(fc => fc.Description)
            .HasColumnType("varchar")
            .HasMaxLength(300);

        builder.Property(fc => fc.IsEnabled)
            .HasColumnType("boolean")
            .IsRequired()
            .HasDefaultValue(false);
    }
}