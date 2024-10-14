using ProcApi.Application.DTOs.Authentication;

namespace ProcApi.Application.Services.Abstracts;

public interface IAuthenticationService
{
    Task Register(RegistrationRequest request);
    Task<string> Login(LoginRequest request);
}