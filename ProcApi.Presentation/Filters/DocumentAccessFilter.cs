using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Localization;
using ProcApi.Domain.Enums;
using ProcApi.Domain.Exceptions;
using ProcApi.Infrastructure.Constants;
using ProcApi.Infrastructure.Repositories.Abstracts;
using ProcApi.Infrastructure.Resources;
using ProcApi.Infrastructure.Utility;

namespace ProcApi.Presentation.Filters;

public class DocumentAccessFilter : ActionFilterAttribute
{
    private readonly Roles[] _roles;

    public DocumentAccessFilter(Roles[] roles)
    {
        _roles = roles;
    }

    public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        var documentActionsRepository = context.HttpContext.RequestServices.GetService<IDocumentActionRepository>()!;
        var userRepository = context.HttpContext.RequestServices.GetService<IUserRepository>()!;
        var localizer = context.HttpContext.RequestServices.GetService<IStringLocalizer<SharedResource>>()!;

        var docId = (int)context.ActionArguments["docId"]!;
        var jwtToken = context.HttpContext.Request.Headers[HeaderKeys.Authorization].ToString();
        var userInfo = JwtUtility.GetUserInfo(jwtToken);

        var exist = await documentActionsRepository.ExistsByDocIdAndUserId(docId, userInfo.UserId);

        if (!exist)
        {
            var roles = await userRepository.GetRolesUnionDelegatedRoles(userInfo.UserId);

            if (!_roles.Any(role => roles.Contains((int)role)))
                throw new ValidationException(localizer["CantAccessDocument"]);
        }

        await next();
    }
}