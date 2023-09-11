namespace ProcApi.Data.ProcDatabase.Models;

public class Group
{
    public int ChatId { get; set; }
    public Chat Chat { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }   
    public ICollection<GroupUser> GroupUsers { get; set; }
}