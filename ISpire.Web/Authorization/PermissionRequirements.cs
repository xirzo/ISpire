using Microsoft.AspNetCore.Authorization;

namespace ISpire.Web.Authorization;

public class PermissionRequirements : IAuthorizationRequirement
{
    public string Permission { get; }
    
    public PermissionRequirements(string permission)
    {
        Permission = permission;
    }
}