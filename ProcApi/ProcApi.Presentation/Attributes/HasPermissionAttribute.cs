using Microsoft.AspNetCore.Authorization;
using ProcApi.Domain.Enums;

namespace ProcApi.Presentation.Attributes;

public class HasPermissionAttribute : AuthorizeAttribute
{
    public HasPermissionAttribute(Permissions permission) : base(policy: permission.ToString())
    {
    }
}