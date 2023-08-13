namespace ProcApi.Data.ProcDatabase.Models;

public class UserPassword
{
    public int UserId { get; set; }
    public User User { get; set; }
    public string PasswordHash { get; set; }
    public string Salt { get; set; }
    public DateTime LastModified { get; set; }
}