using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProcApi.Data.ProcDatabase.Models;

namespace ProcApi.Data.ProcDatabase.Configurations
{
    public class DocumentActionConfiguration : IEntityTypeConfiguration<DocumentAction>
    {
        public void Configure(EntityTypeBuilder<DocumentAction> builder)
        {
            builder.Property(da => da.IsPerformed)
                .HasColumnType("boolean")
                .IsRequired()
                .HasDefaultValue(false);

            builder.HasOne(da => da.Document)
                .WithMany(d => d.DocumentActions)
                .HasForeignKey(da => da.DocumentId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}