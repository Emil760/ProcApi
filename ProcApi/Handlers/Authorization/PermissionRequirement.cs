﻿using Microsoft.AspNetCore.Authorization;

namespace ProcApi.Handlers.Authorization;

public class PermissionRequirement : IAuthorizationRequirement
{
    public PermissionRequirement(string permission)
    {
        Permission = permission;
    }
    
    public string Permission { get; }
}