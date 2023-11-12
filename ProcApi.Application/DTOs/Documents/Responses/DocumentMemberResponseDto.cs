using ProcApi.Domain.Enums;

namespace ProcApi.Application.DTOs.Documents.Responses;

public class DocumentMemberResponseDto
{
    public string AssignerName { get; set; }
    public string PerformerName { get; set; }
    public Roles RoleId { get; set; }
    public DateTime? ActionAssigned { get; set; }
    public bool IsAssigned { get; set; }
    public DateTime? ActionPerformed { get; set; }
    public bool IsPerformed { get; set; }
}