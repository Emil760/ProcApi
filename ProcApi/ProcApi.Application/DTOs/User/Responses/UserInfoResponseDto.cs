using ProcApi.Domain.Enums;

namespace ProcApi.Application.DTOs.User.Responses;

public class UserInfoResponseDto
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public int Age { get; set; }
    public Gender Gender { get; set; }
}
