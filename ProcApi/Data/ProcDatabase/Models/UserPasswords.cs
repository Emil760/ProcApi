namespace ProcApi.Data.ProcDatabase.Models;

public class UserPassword
{
    public int UserId { get; set; }
    public User User { get; set; }
    public required string PasswordHash { get; set; }
    public required string Salt { get; set; }
    public required DateTime LastModified { get; set; }
}