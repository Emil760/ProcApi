namespace ProcApi.Domain.Entities;

public class DocumentAction
{
    public int Id { get; set; }
    public int DocumentId { get; set; }
    public Document Document { get; set; }
    public int AssignerId { get; set; }
    public User Assigner { get; set; }
    public int? PerformerId { get; set; }
    public User? Performer { get; set; }
    public int RoleId { get; set; }
    public Role Role { get; set; }
    public float Order { get; set; }
    public DateTime? ActionPerformed { get; set; }
    public bool IsPerformed { get; set; }
    public DateTime? ActionAssigned { get; set; }
    public bool IsAssigned { get; set; }
}