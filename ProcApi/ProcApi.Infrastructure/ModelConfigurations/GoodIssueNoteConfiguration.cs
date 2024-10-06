using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProcApi.Domain.Entities;

namespace ProcApi.Infrastructure.ModelConfigurations;

public class GoodIssueNoteConfiguration : IEntityTypeConfiguration<GoodIssueNote>
{
    public void Configure(EntityTypeBuilder<GoodIssueNote> builder)
    {
        builder.HasKey(gi => gi.Id);

        builder.Property(gi => gi.Id)
            .ValueGeneratedNever();

        builder.HasOne(gi => gi.Document)
            .WithOne()
            .HasForeignKey<GoodIssueNote>(gi => gi.Id)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(gi => gi.Items)
            .WithOne(gii => gii.GoodIssueNote)
            .HasForeignKey(gii => gii.GoodIssueNoteId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}