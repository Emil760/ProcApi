using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProcApi.Data.ProcDatabase.Models;

namespace ProcApi.Data.ProcDatabase.Configurations
{
    public class ControlSetConfiguration : IEntityTypeConfiguration<ControlSet>
    {
        public void Configure(EntityTypeBuilder<ControlSet> builder)
        {
            builder.Property(cs => cs.IsVisible)
                .HasColumnType("bit")
                .IsRequired()
                .HasDefaultValue(false);

            builder.Property(cs => cs.IsEditable)
                .HasColumnType("bit")
                .IsRequired()
                .HasDefaultValue(false);

            builder.Property(cs => cs.IsMandatory)
                .HasColumnType("bit")
                .IsRequired()
                .HasDefaultValue(false);
        }
    }
}
