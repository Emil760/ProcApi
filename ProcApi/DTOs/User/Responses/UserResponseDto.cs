using ProcApi.Data.ProcDatabase.Enums;

namespace ProcApi.DTOs.User.Responses;

public class UserResponseDto
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
    public Gender Gender { get; set; }
}
