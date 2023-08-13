using Microsoft.AspNetCore.Authorization;
using ProcApi.Enums;

namespace ProcApi.Attributes;

public class HasPermissionAttribute : AuthorizeAttribute
{
    public HasPermissionAttribute(Permissions permission) : base(policy: permission.ToString())
    {
    }
}