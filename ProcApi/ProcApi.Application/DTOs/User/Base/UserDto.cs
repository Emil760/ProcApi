using ProcApi.Domain.Enums;

namespace ProcApi.Application.DTOs.User.Base;

public class UserDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
    public Gender Gender { get; set; }
}