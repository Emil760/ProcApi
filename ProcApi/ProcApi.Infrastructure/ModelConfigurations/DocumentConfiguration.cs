﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProcApi.Domain.Entities;

namespace ProcApi.Infrastructure.ModelConfigurations;

public class DocumentConfiguration : IEntityTypeConfiguration<Document>
{
    public void Configure(EntityTypeBuilder<Document> builder)
    {
        builder.HasKey(d => d.Id);

        builder.Property(d => d.Number)
            .HasColumnType("varchar")
            .HasMaxLength(30);

        builder.Property(d => d.FlowCodes)
            .HasColumnType("varchar")
            .HasMaxLength(300)
            .IsRequired();
        
        builder.HasMany(d => d.Actions)
            .WithOne(da => da.Document)
            .HasForeignKey(da => da.DocumentId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasMany(c => c.Comments)
            .WithOne(d => d.Document)
            .HasForeignKey(d => d.DocumentId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}