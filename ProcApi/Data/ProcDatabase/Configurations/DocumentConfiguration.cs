using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProcApi.Data.ProcDatabase.Models;

namespace ProcApi.Data.ProcDatabase.Configurations;

public class DocumentConfiguration : IEntityTypeConfiguration<Document>
{
    public void Configure(EntityTypeBuilder<Document> builder)
    {
        builder.HasKey(d => d.Id);

        builder.Property(d => d.Number)
            .HasColumnType("varchar")
            .HasMaxLength(30);

        builder.HasMany(d => d.Actions)
            .WithOne(da => da.Document)
            .HasForeignKey(da => da.DocumentId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}