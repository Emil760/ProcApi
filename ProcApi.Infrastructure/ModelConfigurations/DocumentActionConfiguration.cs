using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProcApi.Domain.Entities;

namespace ProcApi.Infrastructure.ModelConfigurations;

public class DocumentActionConfiguration : IEntityTypeConfiguration<DocumentAction>
{
    public void Configure(EntityTypeBuilder<DocumentAction> builder)
    {
        builder.Property(da => da.IsPerformed)
            .HasColumnType("boolean")
            .IsRequired()
            .HasDefaultValue(false);

        builder.Property(da => da.IsAssigned)
            .HasColumnType("boolean")
            .IsRequired()
            .HasDefaultValue(true);

        builder.HasOne(da => da.Document)
            .WithMany(d => d.Actions)
            .HasForeignKey(da => da.DocumentId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(da => da.Assigner)
            .WithMany()
            .HasForeignKey(da => da.AssignerId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(da => da.Performer)
            .WithMany()
            .HasForeignKey(da => da.PerformerId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.NoAction);
    }
}