using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProcApi.Domain.Entities;

namespace ProcApi.Infrastructure.ModelConfigurations;

public class DropDownSourceConfiguration : IEntityTypeConfiguration<DropDownSource>
{
    public void Configure(EntityTypeBuilder<DropDownSource> builder)
    {
        builder.Property(d => d.Key)
            .HasColumnType("varchar")
            .HasMaxLength(300)
            .IsRequired();

        builder.HasMany(d => d.Items)
            .WithOne(di => di.DropDownSource)
            .HasForeignKey(di => di.DropDownSourceId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasIndex(u => u.Key)
            .IsUnique();
    }
}