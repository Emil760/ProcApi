using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProcApi.Domain.Entities;

namespace ProcApi.Infrastructure.ModelConfigurations;

public class GoodReceiptNoteConfiguration : IEntityTypeConfiguration<GoodReceiptNote>
{
    public void Configure(EntityTypeBuilder<GoodReceiptNote> builder)
    {
        builder.HasKey(gr => gr.DocumentId);

        builder.Property(gr => gr.DocumentId)
            .ValueGeneratedNever();

        builder.HasOne(gr => gr.Document)
            .WithOne()
            .HasForeignKey<GoodReceiptNote>(prd => prd.DocumentId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(gr => gr.Items)
            .WithOne(gri => gri.GoodReceiptNote)
            .HasForeignKey(gri => gri.GoodReceiptNoteId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}