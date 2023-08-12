using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProcApi.Data.ProcDatabase.Models;

namespace ProcApi.Data.ProcDatabase.Configurations
{
    public class PurchaseRequestDocumentConfiguration : IEntityTypeConfiguration<PurchaseRequestDocument>
    {
        public void Configure(EntityTypeBuilder<PurchaseRequestDocument> builder)
        {
            builder.HasKey(prd => prd.DocumentId);

            builder.HasOne(prd => prd.Document)
                .WithOne()
                .HasForeignKey<PurchaseRequestDocument>(prd => prd.DocumentId);
        }
    }
}
