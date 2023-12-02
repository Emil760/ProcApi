namespace ProcApi.Domain.Entities;

public class Delegation
{
    public int Id { get; set; }
    public int FromUserId { get; set; }
    public User FromUser { get; set; }
    public int ToUserId { get; set; }
    public User ToUser { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}