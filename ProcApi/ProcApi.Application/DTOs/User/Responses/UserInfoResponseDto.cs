using ProcApi.Application.DTOs.User.Base;

namespace ProcApi.Application.DTOs.User.Responses;

public class UserInfoResponseDto : UserDto
{
    public int Id { get; set; }
    public int DepartmentId { get; set; }
    public string DepartmentName { get; set; }
    public int DashboardId { get; set; }
    public string DashboardName { get; set; }
}