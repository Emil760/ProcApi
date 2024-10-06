using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProcApi.Domain.Entities;

namespace ProcApi.Infrastructure.ModelConfigurations;

public class InvoiceConfiguration : IEntityTypeConfiguration<Invoice>
{
    public void Configure(EntityTypeBuilder<Invoice> builder)
    {
        builder.HasKey(prd => prd.Id);

        builder.Property(prd => prd.Id)
            .ValueGeneratedNever();

        builder.HasOne(id => id.Document)
            .WithOne()
            .HasForeignKey<Invoice>(id => id.Id)
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
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Cascade);
    }
}