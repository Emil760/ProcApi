namespace ProcApi.Data.ProcDatabase.Models;

public class DocumentAction
{
    public int Id { get; set; }
    public int DocumentId { get; set; }
    public required Document Document { get; set; }
    public int UserId { get; set; }
    public required User User { get; set; }
    public int RoleId { get; set; }
    public required Role Role { get; set; }
    public int Order { get; set; }
    public DateTime? ActionPerformed { get; set; }
    public bool IsPerformed { get; set; }
}