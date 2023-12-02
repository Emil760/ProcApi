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
    private readonly Permissions[] _permissions;

    public DocumentAccessFilter(Permissions[] permissions)
    {
        _permissions = permissions;
    }

    public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        var documentActionsRepository = context.HttpContext.RequestServices.GetService<IDocumentActionRepository>()!;
        var localizer = context.HttpContext.RequestServices.GetService<IStringLocalizer<SharedResource>>()!;

        var docId = (int)context.ActionArguments["docId"]!;
        var jwtToken = context.HttpContext.Request.Headers[HeaderKeys.Authorization].ToString();
        var userInfo = JwtUtility.GetUserInfo(jwtToken);
        var userPermissions = JwtUtility.GetUserPermissions(jwtToken);

        var exist = await documentActionsRepository.ExistsByDocIdAndAssignerIdOrHasDelegation(docId, userInfo.UserId);

        if (!exist)
        {
            foreach (var permission in _permissions)
            {
                if (userPermissions.Contains(permission))
                {
                    await next();
                    return;
                }
            }

            throw new ValidationException(localizer["CantAccessDocument"]);
        }

        await next();
    }
}