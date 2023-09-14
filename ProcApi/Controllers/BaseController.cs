using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProcApi.DTOs.User.Base;
using ProcApi.Utility;

namespace ProcApi.Controllers
{
    [Authorize]
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected UserInfo UserInfo => JwtUtility.GetUserInfo(Request.Headers["Authorization"]);

        public BaseController()
        {
        }
    }
}