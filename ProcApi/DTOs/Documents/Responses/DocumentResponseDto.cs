using ProcApi.DTOs.Documents.Base;

namespace ProcApi.DTOs.Documents.Responses;

public class DocumentResponseDto : BaseDocumentDto
{
    public IEnumerable<DocumentMemberResponseDto> Members { get; set; }
}