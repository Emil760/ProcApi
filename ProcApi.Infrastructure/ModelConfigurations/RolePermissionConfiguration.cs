using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProcApi.Domain.Entities;
using ProcApi.Domain.Enums;

namespace ProcApi.Infrastructure.ModelConfigurations;

public class RolePermissionConfiguration : IEntityTypeConfiguration<RolePermission>
{
    public void Configure(EntityTypeBuilder<RolePermission> builder)
    {
        builder.HasKey(rp => new { rp.RoleId, rp.PermissionId });

        builder.HasData(Seed());
    }

    private IEnumerable<RolePermission> Seed()
    {
        return new[]
        {
            new RolePermission { RoleId = (int) Roles.Admin, PermissionId = (int)Permissions.CanDeleteUser },
            new RolePermission { RoleId = (int) Roles.User, PermissionId = (int)Permissions.CanActivateUser },
            new RolePermission { RoleId = (int) Roles.User, PermissionId = (int)Permissions.CanEditUser },
            new RolePermission { RoleId = (int) Roles.Requester, PermissionId = (int) Permissions.CanCreatePurchaseRequest },
            new RolePermission { RoleId = (int) Roles.Buyer, PermissionId = (int) Permissions.CanCreateInvoice }

        };
    }
}