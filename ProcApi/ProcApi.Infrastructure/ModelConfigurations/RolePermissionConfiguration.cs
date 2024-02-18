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

        Seed(builder);
    }

    private void Seed(EntityTypeBuilder<RolePermission> builder)
    {
        var adminPermissions = Enum.GetValues(typeof(Permissions));

        foreach (var adminPermission in adminPermissions)
            builder.HasData(new RolePermission { RoleId = (int)Roles.Admin, PermissionId = (int)adminPermission });

        builder.HasData(new RolePermission
        {
            RoleId = (int)Roles.User,
            PermissionId = (int)Permissions.CanActivateUser
        });
        builder.HasData(new RolePermission
        {
            RoleId = (int)Roles.User,
            PermissionId = (int)Permissions.CanEditUser
        });
        builder.HasData(new RolePermission
        {
            RoleId = (int)Roles.Requester,
            PermissionId = (int)Permissions.CanCreatePurchaseRequest
        });
        builder.HasData(new RolePermission
        {
            RoleId = (int)Roles.Requester,
            PermissionId = (int)Permissions.CanViewPurchaseRequest
        });
        builder.HasData(new RolePermission
        {
            RoleId = (int)Roles.Buyer,
            PermissionId = (int)Permissions.CanCreateInvoice
        });
        builder.HasData(new RolePermission
        {
            RoleId = (int)Roles.Buyer,
            PermissionId = (int)Permissions.CanViewInvoice
        });
        builder.HasData(new RolePermission
        {
            RoleId = (int)Roles.Buyer,
            PermissionId = (int)Permissions.CanChangeReviewer
        });
        builder.HasData(new RolePermission
        {
            RoleId = (int)Roles.Finance,
            PermissionId = (int)Permissions.CanViewInvoice
        });
        builder.HasData(new RolePermission
        {
            RoleId = (int)Roles.Coordinator,
            PermissionId = (int)Permissions.CanViewInvoice
        });
        builder.HasData(new RolePermission
        {
            RoleId = (int)Roles.Director,
            PermissionId = (int)Permissions.CanCreateDelegation
        });
        builder.HasData(new RolePermission
        {
            RoleId = (int)Roles.HeadDepartment,
            PermissionId = (int)Permissions.CanViewPurchaseRequest
        });
        builder.HasData(new RolePermission
        {
            RoleId = (int)Roles.ProcurementDirector,
            PermissionId = (int)Permissions.CanViewPurchaseRequest
        });
        builder.HasData(new RolePermission
        {
            RoleId = (int)Roles.ProcurementDirector,
            PermissionId = (int)Permissions.CanAssignBuyer
        });
    }
}