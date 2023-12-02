using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProcApi.Domain.Entities;

namespace ProcApi.Infrastructure.ModelConfigurations;

public class SupplierConfiguration : IEntityTypeConfiguration<Supplier>
{
    public void Configure(EntityTypeBuilder<Supplier> builder)
    {
        builder.Property(s => s.Name)
            .HasColumnType("varchar")
            .HasMaxLength(300)
            .IsRequired();

        builder.HasIndex(s => s.Name)
            .IsUnique();

        builder.Property(s => s.Mail)
            .HasColumnType("varchar")
            .HasMaxLength(150)
            .IsRequired();

        builder.Property(s => s.TaxId)
            .HasColumnType("char")
            .HasMaxLength(10)
            .IsFixedLength()
            .IsRequired();

        builder.HasIndex(s => s.TaxId)
            .IsUnique();

        builder.Property(s => s.IsActive)
            .HasColumnType("boolean")
            .IsRequired()
            .HasDefaultValue(true);
    }
}