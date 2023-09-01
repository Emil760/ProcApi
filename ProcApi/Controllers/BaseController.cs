using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProcApi.DTOs.User;
using ProcApi.DTOs.User.Base;

namespace ProcApi.Controllers
{
    [Authorize]
    [ApiController]
    public class BaseController : ControllerBase
    {
        public UserInfo UserInfo { get; set; }

        public BaseController()
        {
        }
    }
}