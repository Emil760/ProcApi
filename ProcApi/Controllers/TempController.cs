using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ProcApi.Controllers;
using ProcApi.Exceptions;
using ProcApi.Repositories.Abstracts;
using ProcApi.Services.Abstracts;
using ValidationException = ProcApi.Exceptions.ValidationException;

namespace ProcApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class TempController : BaseController
    {
        private readonly IUserService _userService;
        private readonly IUserRepository _userRepository;
        private readonly ILogger<TempController> _logger;

        public TempController(IUserService userService,
            IUserRepository userRepository,
            ILogger<TempController> logger)
        {
            _userService = userService;
            _userRepository = userRepository;
            _logger = logger;
        }

        [HttpGet("Test")]
        public async Task<IActionResult> GetTemp()
        {
            _logger.LogInformation("aaaa");
            throw new Exception("a1");
            return Ok();
        }

        [HttpGet("Test2")]
        public IActionResult GetTemp2()
        {
            throw new UnauthorizedException("a2");
            return Ok();
        }

        [HttpGet("Test3")]
        public async Task<IActionResult> GetTemp3()
        {
            throw new ValidationException("a3");
            return Ok();
        }
    }
}