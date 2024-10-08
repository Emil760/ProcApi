﻿using ProcApi.Domain.Interfaces;

namespace ProcApi.Domain.Entities;

public class Department : IEntity<int>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int HeadUserId { get; set; }
    public User HeadUser { get; set; }
    public ICollection<User> Users { get; set; }
}