using ProcApi.Data.ProcDatabase.Enums;

namespace ProcApi.DTOs.Authentication;

public class RegistrationDto
{
    public required string Login { get; set; }
    public required string FirstName { get; set; }
    public required Gender Gender { get; set; }
    public required string Password { get; set; }
}