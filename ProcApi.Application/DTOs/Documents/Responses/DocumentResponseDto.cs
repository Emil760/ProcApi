using ProcApi.Application.DTOs.Documents.Base;

namespace ProcApi.Application.DTOs.Documents.Responses;

public class DocumentResponseDto : BaseDocumentDto
{
    public IEnumerable<DocumentMemberResponseDto> Members { get; set; }
}