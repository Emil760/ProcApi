using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProcApi.DTOs.User;

namespace ProcApi.Controllers
{
    //[CustomValidationFilter]
    [Authorize]
    [ApiController]
    public class BaseController : ControllerBase
    {
        public UserInfoDro UserInfoDro { get; set; }

        public BaseController()
        {
        }
    }
}