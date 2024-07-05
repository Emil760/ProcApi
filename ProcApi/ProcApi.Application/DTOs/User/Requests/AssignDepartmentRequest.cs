namespace ProcApi.Application.DTOs.User.Requests;

public class AssignDepartmentRequest
{
    public int DepartmentId { get; set; }
    public int UserId { get; set; }
}