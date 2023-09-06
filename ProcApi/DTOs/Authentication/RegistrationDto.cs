using ProcApi.Data.ProcDatabase.Enums;

namespace ProcApi.DTOs.Authentication;

public class RegistrationDto
{
    public string Login { get; set; }
    public string FirstName { get; set; }
    public Gender Gender { get; set; }
    public string Password { get; set; }
}