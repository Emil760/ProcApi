using ProcApi.DTOs.Authentication;

namespace ProcApi.Services.Abstracts;

public interface IAuthenticationService
{
    Task Register(RegistrationDto dto);

    Task<string> Login(LoginDto dto);
}