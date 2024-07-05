using ProcApi.Application.DTOs.Project.Base;

namespace ProcApi.Application.DTOs.Project.Requests;

public class UpdateProjectRequest : ProjectDto
{
    public int Id { get; set; }
}