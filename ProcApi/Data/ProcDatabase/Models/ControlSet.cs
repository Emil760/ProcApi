using ProcApi.Data.ProcDatabase.Enums;

namespace ProcApi.Data.ProcDatabase.Models
{
    public class ControlSet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        //public string ActionCode { get; set; }
        public int? ActionTypeId { get; set; }
        public ActionType ActionType { get; set; }
        public int DocumentTypeId { get; set; }
        public DocumentType DocumentType { get; set; }
        public int DocumentStatusId { get; set; }
        public DocumentStatus DocumentStatus { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
        public bool IsVisible { get; set; }
        public bool IsEdiatable { get; set; }
        public bool IsMandatory { get; set; }
    }
}
