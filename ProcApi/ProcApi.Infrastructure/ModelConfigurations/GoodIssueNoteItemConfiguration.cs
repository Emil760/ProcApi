using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProcApi.Domain.Entities;

namespace ProcApi.Infrastructure.ModelConfigurations;

public class GoodIssueNoteItemConfiguration : IEntityTypeConfiguration<GoodIssueNoteItem>
{
    public void Configure(EntityTypeBuilder<GoodIssueNoteItem> builder)
    {
        builder.HasOne(gii => gii.GoodIssueNote)
            .WithMany(gi => gi.Items)
            .HasForeignKey(gii => gii.GoodIssueNoteId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}