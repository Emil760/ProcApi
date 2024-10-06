using ProcApi.Domain.Enums;
using ProcApi.Domain.Interfaces;

namespace ProcApi.Domain.Entities;

public class GroupUser : IEntity<int>
{
    public int Id { get; set; }
    public ChatUser ChatUser { get; set; }
    public int GroupId { get; set; }
    public Group Group { get; set; }
    public ChatRole ChatRole { get; set; }
    public bool IsLeaved { get; set; }
}