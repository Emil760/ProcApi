using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ProcApi.Controllers
{
    //[CustomValidationFilter]
    [Authorize]
    [ApiController]
    public class BaseController : ControllerBase
    {
        public BaseController()
        {

        }
    }
}
