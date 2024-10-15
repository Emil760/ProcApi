using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProcApi.Domain.Entities;

namespace ProcApi.Infrastructure.ModelConfigurations;

public class DocumentTypeStatusConfiguration : IEntityTypeConfiguration<DocumentTypeStatus>
{
    public void Configure(EntityTypeBuilder<DocumentTypeStatus> builder)
    {
        builder.Property(x => x.DocumentType)
            .IsRequired();

        builder.Property(x => x.DocumentStatus)
            .IsRequired();

        builder.HasMany(x => x.DashboardSections)
            .WithOne(ds => ds.DocumentTypeStatus)
            .HasForeignKey(x => x.DocumentTypeStatusId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(x => new { x.DocumentType, x.DocumentStatus })
            .IsUnique();
    }
}