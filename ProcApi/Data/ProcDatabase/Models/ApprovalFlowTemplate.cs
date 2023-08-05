using ProcApi.Data.ProcDatabase.Enums;

namespace ProcApi.Data.ProcDatabase.Models
{
    public class ApprovalFlowTemplate
    {
        public int Id { get; set; }
        public int DocumentTypeId { get; set; }
        public DocumentType DocumentType { get; set; }
        public int Order { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
        public int? UserId { get; set; }
        public User User { get; set; }
        public bool IsInitial { get; set; }
        public bool IsCreator { get; set; }
    }
}
