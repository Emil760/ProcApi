namespace ProcApi.Data.ProcDatabase.Models
{
    public class PurchageRequestDocument
    {
        public int DocumentId { get; set; }
        public Document Document { get; set; }
        public int RequestedForDepartmentId { get; set; }
        public Departament RequestedForDepartment { get; set; }
        public string Description { get; set; }
        public int ProjectId { get; set; }
        public Project Project { get; set; }
    }
}
