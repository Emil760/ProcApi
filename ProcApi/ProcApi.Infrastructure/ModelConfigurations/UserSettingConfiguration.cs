﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProcApi.Domain.Entities;

namespace ProcApi.Infrastructure.ModelConfigurations;

public class UserSettingConfiguration : IEntityTypeConfiguration<UserSetting>
{
    public void Configure(EntityTypeBuilder<UserSetting> builder)
    {
        builder.HasKey(us => us.Id);

        builder.Property(us => us.Id)
            .ValueGeneratedNever();

        builder.HasOne(us => us.User)
            .WithOne(u => u.UserSetting)
            .HasForeignKey<UserSetting>(u => u.Id)
            .OnDelete(DeleteBehavior.Cascade);
    }
}