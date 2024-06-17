using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProcApi.Domain.Entities;

namespace ProcApi.Infrastructure.ModelConfigurations;

public class GoodReceiptNoteConfiguration : IEntityTypeConfiguration<GoodReceiptNote>
{
    public void Configure(EntityTypeBuilder<GoodReceiptNote> builder)
    {
        builder.HasKey(prd => prd.DocumentId);

        builder.Property(prd => prd.DocumentId)
            .ValueGeneratedNever();

        builder.HasOne(prd => prd.Document)
            .WithOne()
            .HasForeignKey<GoodIssueNote>(prd => prd.DocumentId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}