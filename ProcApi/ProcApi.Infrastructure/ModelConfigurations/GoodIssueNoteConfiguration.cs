using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProcApi.Domain.Entities;

namespace ProcApi.Infrastructure.ModelConfigurations;

public class GoodIssueNoteConfiguration : IEntityTypeConfiguration<GoodIssueNote>
{
    public void Configure(EntityTypeBuilder<GoodIssueNote> builder)
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