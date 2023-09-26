using Microsoft.AspNetCore.Authorization;
using ProcApi.Application.Constants;

namespace ProcApi.Presentation.Handlers.Authorization;

public class PermissionAuthorizationHandler : AuthorizationHandler<PermissionRequirement>
{
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context,
        PermissionRequirement requirement)
    {
        var permissions = context.User.Claims
            .Where(c => c.Type == ClaimKeys.Permission)
            .Select(c => c.Value);

        if (permissions.Contains(requirement.Permission))
            context.Succeed(requirement);

        return Task.CompletedTask;
    }
}