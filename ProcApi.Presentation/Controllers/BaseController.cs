using Microsoft.AspNetCore.Mvc;
using ProcApi.Infrastructure.Utility;
using ProcApi.Domain.Models;
using ProcApi.Infrastructure.Constants;

namespace ProcApi.Presentation.Controllers;

[ApiController]
public class BaseController : ControllerBase
{
    protected UserInfoModel UserInfo => JwtUtility.GetUserInfo(Request.Headers[HeaderKeys.Authorization]);
}