using Microsoft.AspNetCore.Mvc;
using ProcApi.DTOs.Authentication;

namespace ProcApi.Controllers;

public class AuthenticationController : BaseController
{
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDto dto)
    {
        return Ok();
    }

    [HttpPost]
    public async Task<IActionResult> Register([FromBody] RegistrationDto dto)
    {
        return Ok();
    }
}