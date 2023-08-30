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

            builder.Property(prd => prd.DocumentId)
                .ValueGeneratedNever();

            builder.HasOne(prd => prd.Document)
                .WithOne()
                .HasForeignKey<PurchaseRequestDocument>(d => d.DocumentId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(prd => prd.RequestedForDepartment)
                .WithMany()
                .HasForeignKey(prd => prd.RequestedForDepartmentId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(prd => prd.Project)
                .WithMany()
                .HasForeignKey(prd => prd.ProjectId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}