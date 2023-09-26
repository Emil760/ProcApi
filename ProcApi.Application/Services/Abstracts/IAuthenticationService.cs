using ProcApi.Application.DTOs.Authentication;

namespace ProcApi.Application.Services.Abstracts;

public interface IAuthenticationService
{
    Task Register(RegistrationDto dto);

    Task<string> Login(LoginDto dto);
}