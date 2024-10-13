using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProcApi.Domain.Entities;

namespace ProcApi.Infrastructure.ModelConfigurations;

public class DocumentNumberPatternConfiguration : IEntityTypeConfiguration<DocumentNumberPattern>
{
    public void Configure(EntityTypeBuilder<DocumentNumberPattern> builder)
    {
        builder.Property(x => x.Name)
            .HasColumnType("varchar(300)")
            .IsRequired();

        builder.Property(x => x.CreatedDate)
            .HasColumnType("timestamp")
            .IsRequired()
            .HasDefaultValueSql("CURRENT_TIMESTAMP");

        builder.Property(x => x.IsActive)
            .HasColumnType("boolean")
            .IsRequired()
            .HasDefaultValue(true);

        builder.HasMany(x => x.Documents)
            .WithOne(x => x.DocumentNumberPattern)
            .HasForeignKey(x => x.DocumentNumberPatternId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(x => x.DocumentNumberSections)
            .WithOne(x => x.DocumentNumberPattern)
            .HasForeignKey(x => x.DocumentNumberPatternId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}