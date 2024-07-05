using ProcApi.Domain.Enums;

namespace ProcApi.Application.DTOs.Authentication;

public class RegistrationRequest
{
    public string Login { get; set; }
    public string FirstName { get; set; }
    public Gender Gender { get; set; }
    public string Password { get; set; }
}