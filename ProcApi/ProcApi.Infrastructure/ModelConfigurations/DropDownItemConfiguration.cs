using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProcApi.Domain.Entities;

namespace ProcApi.Infrastructure.ModelConfigurations;

public class DropDownItemConfiguration : IEntityTypeConfiguration<DropDownItem>
{
    public void Configure(EntityTypeBuilder<DropDownItem> builder)
    {
        builder.Property(di => di.Value)
            .HasColumnType("varchar")
            .HasMaxLength(300)
            .IsRequired();

        builder.HasOne(di => di.DropDownSource)
            .WithMany(d => d.Items)
            .HasForeignKey(di => di.DropDownSourceId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}