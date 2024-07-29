using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProcApi.Domain.Entities;

namespace ProcApi.Infrastructure.ModelConfigurations;

public class GoodIssueNoteItemConfiguration : IEntityTypeConfiguration<GoodIssueNoteItem>
{
    public void Configure(EntityTypeBuilder<GoodIssueNoteItem> builder)
    {
        builder.HasOne(gini => gini.GoodIssueNote)
            .WithMany(gin => gin.Items)
            .HasForeignKey(gini => gini.GoodIssueNoteId)
            .OnDelete(DeleteBehavior.Cascade);
            
        builder.HasOne(gini => gini.Material)
            .WithMany()
            .HasForeignKey(gini => gini.MaterialId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(gini => gini.UnitOfMeasure)
            .WithMany()
            .HasForeignKey(gini => gini.UnitOfMeasureId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}