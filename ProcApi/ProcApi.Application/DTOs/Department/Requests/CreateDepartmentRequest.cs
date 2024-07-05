namespace ProcApi.Application.DTOs.Department.Requests;

public class CreateDepartmentRequest
{
    public string Name { get; set; }
    public int HeadUserId { get; set; }
}