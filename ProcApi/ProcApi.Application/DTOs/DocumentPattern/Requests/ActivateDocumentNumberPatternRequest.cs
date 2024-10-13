namespace ProcApi.Application.DTOs.DocumentPattern.Requests
{
    public class ActivateDocumentNumberPatternRequest
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
    }
}
