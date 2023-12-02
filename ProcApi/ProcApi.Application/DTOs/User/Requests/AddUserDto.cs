using ProcApi.Domain.Enums;

namespace ProcApi.Application.DTOs.User.Requests;

public class AddUserDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
    public Gender Gender { get; set; }
}