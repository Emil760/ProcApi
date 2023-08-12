namespace ProcApi.DTOs.Authentication;

public class RegistrationDto
{
    public required string Login { get; set; }
    public required string Password { get; set; }
}