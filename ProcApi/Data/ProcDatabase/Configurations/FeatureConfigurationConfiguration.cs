using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProcApi.Data.ProcDatabase.Models;

namespace ProcApi.Data.ProcDatabase.Configurations
{
    public class FeatureConfigurationConfiguration : IEntityTypeConfiguration<FeatureConfiguration>
    {
        public void Configure(EntityTypeBuilder<FeatureConfiguration> builder)
        {
            builder.Property(fc => fc.IsEnabled)
                .HasColumnType("bit")
                .IsRequired()
                .HasDefaultValue(false);
        }
    }
}
