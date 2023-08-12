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
                .HasColumnType("bit")
                .IsRequired()
                .HasDefaultValue(false);
        }
    }
}
