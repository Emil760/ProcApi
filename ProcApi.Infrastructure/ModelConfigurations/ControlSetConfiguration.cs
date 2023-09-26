using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProcApi.Domain.Entities;

namespace ProcApi.Infrastructure.ModelConfigurations
{
    public class ControlSetConfiguration : IEntityTypeConfiguration<ControlSet>
    {
        public void Configure(EntityTypeBuilder<ControlSet> builder)
        {
            builder.Property(cs => cs.Name)
                .HasColumnType("varchar")
                .HasMaxLength(300);

            builder.Property(cs => cs.Description)
                .HasColumnType("varchar")
                .HasMaxLength(300);

            builder.Property(cs => cs.IsVisible)
                .HasColumnType("boolean")
                .IsRequired()
                .HasDefaultValue(false);

            builder.Property(cs => cs.IsEditable)
                .HasColumnType("boolean")
                .IsRequired()
                .HasDefaultValue(false);

            builder.Property(cs => cs.IsMandatory)
                .HasColumnType("boolean")
                .IsRequired()
                .HasDefaultValue(false);
        }
    }
}
