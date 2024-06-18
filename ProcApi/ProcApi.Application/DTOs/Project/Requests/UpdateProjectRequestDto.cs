using ProcApi.Application.DTOs.Project.Base;

namespace ProcApi.Application.DTOs.Project.Requests;

public class UpdateProjectRequestDto : ProjectDto
{
    public int Id { get; set; }
}