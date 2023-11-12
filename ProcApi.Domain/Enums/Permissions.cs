namespace ProcApi.Domain.Enums;

public enum Permissions
{
    CanCreateUser = 1,
    CanDeleteUser,
    CanEditUser,
    CanActivateUser,
    CanCreatePurchaseRequest,
    CanCreateInvoice,
    CanViewMaterial,
    CanViewInvoice,
    CanDeleteMaterial,
    CanCreateMaterial,
    CanViewPurchaseRequest,
    CanViewSupplier,
    CanCreateSupplier,
    CanViewUser,
    CanCreateDelegation,
    CanViewDelegation,
    CanCreateDepartment,
    CanAssignUserDepartment,
    CanReturnInvoice,
    CanRejectInvoice,
    CanReturnPurchaseRequest,
    CanRejectPurchaseRequest
}