using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProcApi.Application.DTOs.Authentication;
using ProcApi.Application.Services.Abstracts;

namespace ProcApi.Presentation.Controllers;

public class AuthenticationController : BaseController
{
    private readonly IAuthenticationService _authenticationService;
    
    public AuthenticationController(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }
    
    [AllowAnonymous]
    [HttpPost("Login")]
    public async Task<IActionResult> Login([FromBody] LoginDto dto)
    {
        var token = await _authenticationService.Login(dto);
        return Ok(token);
    }

    [AllowAnonymous]
    [HttpPost("Register")]
    public async Task<IActionResult> Register([FromBody] RegistrationDto dto)
    {
        await _authenticationService.Register(dto);
        return Ok();
    }
}