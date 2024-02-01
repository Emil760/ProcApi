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
            new RolePermission { RoleId = (int) Roles.Admin, PermissionId = (int)Permissions.CanCreateDelegation },
            new RolePermission { RoleId = (int) Roles.Admin, PermissionId = (int)Permissions.CanActivateUser },
            new RolePermission { RoleId = (int) Roles.Admin, PermissionId = (int)Permissions.CanEditUser },
            new RolePermission { RoleId = (int) Roles.Admin, PermissionId = (int)Permissions.CanCreateMaterial },
            new RolePermission { RoleId = (int) Roles.Admin, PermissionId = (int)Permissions.CanDeleteMaterial },
            new RolePermission { RoleId = (int) Roles.Admin, PermissionId = (int)Permissions.CanCreateSupplier },
            new RolePermission { RoleId = (int) Roles.Admin, PermissionId = (int)Permissions.CanDeleteUser },
            new RolePermission { RoleId = (int) Roles.Admin, PermissionId = (int)Permissions.CanViewDelegation },
            new RolePermission { RoleId = (int) Roles.Admin, PermissionId = (int)Permissions.CanViewMaterial },
            new RolePermission { RoleId = (int) Roles.Admin, PermissionId = (int)Permissions.CanViewSupplier },
            new RolePermission { RoleId = (int) Roles.Admin, PermissionId = (int)Permissions.CanViewUser },
            new RolePermission { RoleId = (int) Roles.Admin, PermissionId = (int)Permissions.CanViewInvoice },
            new RolePermission { RoleId = (int) Roles.Admin, PermissionId = (int)Permissions.CanViewPurchaseRequest },
            new RolePermission { RoleId = (int) Roles.Admin, PermissionId = (int)Permissions.CanViewAll },
            new RolePermission { RoleId = (int) Roles.Admin, PermissionId = (int)Permissions.CanGrantRole },
            new RolePermission { RoleId = (int) Roles.Admin, PermissionId = (int)Permissions.CanRemoveRole },
            new RolePermission { RoleId = (int) Roles.User, PermissionId = (int)Permissions.CanActivateUser },
            new RolePermission { RoleId = (int) Roles.User, PermissionId = (int)Permissions.CanEditUser },
            new RolePermission { RoleId = (int) Roles.Requester, PermissionId = (int) Permissions.CanCreatePurchaseRequest },
            new RolePermission { RoleId = (int) Roles.Requester, PermissionId = (int) Permissions.CanViewPurchaseRequest },
            new RolePermission { RoleId = (int) Roles.Buyer, PermissionId = (int) Permissions.CanCreateInvoice },
            new RolePermission { RoleId = (int) Roles.Buyer, PermissionId = (int)Permissions.CanViewInvoice },
            new RolePermission { RoleId = (int) Roles.Buyer, PermissionId = (int)Permissions.CanChangeReviewer },
            new RolePermission { RoleId = (int) Roles.Finance, PermissionId = (int)Permissions.CanViewInvoice },
            new RolePermission { RoleId = (int) Roles.Coordinator, PermissionId = (int)Permissions.CanViewInvoice },
            new RolePermission { RoleId = (int) Roles.Director, PermissionId = (int)Permissions.CanCreateDelegation },
            new RolePermission { RoleId = (int) Roles.HeadDepartment, PermissionId = (int)Permissions.CanViewPurchaseRequest },
            new RolePermission { RoleId = (int) Roles.ProcurementDirector, PermissionId = (int)Permissions.CanViewPurchaseRequest },
            new RolePermission { RoleId = (int) Roles.ProcurementDirector, PermissionId = (int)Permissions.CanAssignBuyer },
        };
    }
}