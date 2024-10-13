using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProcApi.Domain.Entities;

namespace ProcApi.Infrastructure.ModelConfigurations;

public class DocumentNumberSectionConfiguration : IEntityTypeConfiguration<DocumentNumberSection>
{
    public void Configure(EntityTypeBuilder<DocumentNumberSection> builder)
    {
        builder.HasOne(x => x.DocumentNumberPattern)
            .WithMany(x => x.DocumentNumberSections)
            .HasForeignKey(x => x.DocumentNumberPatternId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Property(x => x.SectionType)
            .HasColumnType("int")
            .IsRequired();

        builder.Property(x => x.Order)
            .HasColumnType("smallint")
            .IsRequired();

        builder.Property(x => x.Format)
            .HasColumnType("varchar(300)")
            .IsRequired(false);

        builder.Property(x => x.Delimiter)
            .HasColumnType("varchar(300)")
            .IsRequired(false);

        builder.Property(x => x.Value)
            .HasColumnType("varchar(300)")
            .IsRequired(false);
    }
}