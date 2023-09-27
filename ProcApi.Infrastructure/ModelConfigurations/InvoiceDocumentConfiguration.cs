using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProcApi.Domain.Entities;

namespace ProcApi.Infrastructure.ModelConfigurations;

public class InvoiceDocumentConfiguration : IEntityTypeConfiguration<InvoiceDocument>
{
    public void Configure(EntityTypeBuilder<InvoiceDocument> builder)
    {
        builder.HasKey(prd => prd.DocumentId);

        builder.Property(prd => prd.DocumentId)
            .ValueGeneratedNever();

        builder.HasOne(id => id.Document)
            .WithOne()
            .HasForeignKey<InvoiceDocument>(id => id.DocumentId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Property(id => id.Description)
            .HasColumnType("varchar")
            .HasMaxLength(4000)
            .IsRequired(false);

        builder.Property(id => id.TotalItemsPrice)
            .HasColumnType("decimal")
            .IsRequired()
            .HasDefaultValue(0);

        builder.HasOne(id => id.Supplier)
            .WithMany()
            .HasForeignKey(id => id.SupplierId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}