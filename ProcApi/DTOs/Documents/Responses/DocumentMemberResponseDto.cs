using ProcApi.Enums;

namespace ProcApi.DTOs.Documents.Responses;

public class DocumentMemberResponseDto
{
    public string MemberName { get; set; }
    public Roles RoleId { get; set; }
    public DateTime? ActionPerformed { get; set; }
    public bool IsPerformed { get; set; }
}