namespace ProcApi.Data.ProcDatabase.Models;

public class UserSetting
{
    public int UserId { get; set; }
    public User User { get; set; }
    public string Language { get; set; }
}