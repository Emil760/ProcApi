﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProcApi.Domain.Entities;
using ProcApi.Domain.Enums;

namespace ProcApi.Infrastructure.ModelConfigurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(u => u.Gender)
                .HasColumnType("int")
                .IsRequired()
                .HasDefaultValue(Gender.Unknown);

            builder.HasMany(u => u.Roles)
                .WithMany()
                .UsingEntity<UserRole>();

            builder.HasMany(u => u.FromDelegations)
                .WithOne(fd => fd.FromUser)
                .HasForeignKey(d => d.FromUserId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(u => u.ToDelegations)
                .WithOne(td => td.ToUser)
                .HasForeignKey(d => d.ToUserId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(u => u.Documents)
                .WithOne(d => d.CreatedBy)
                .HasForeignKey(d => d.CreatedById)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(u => u.DocumentActions)
                .WithOne(da => da.User)
                .HasForeignKey(da => da.UserId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}