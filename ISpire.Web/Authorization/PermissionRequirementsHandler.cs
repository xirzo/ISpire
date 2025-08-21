using System.Security.Claims;
using ISpire.Core.Repositories;
using Microsoft.AspNetCore.Authorization;

namespace ISpire.Web.Authorization;

public class PermissionRequirementsHandler(IServiceScopeFactory serviceScopeFactory) : AuthorizationHandler<PermissionRequirements>
{
    protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionRequirements requirement)
    {
        var userGuid = context.User.Claims
            .FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);

        if (userGuid == null)
        {
            Console.WriteLine("No valid user GUID found");
            return;
        }
        
        if (!Guid.TryParse(userGuid.Value, out var guid))
        {
            Console.WriteLine("Failed to parse user ID as GUID");
            return;
        }

        using var scope = serviceScopeFactory.CreateScope();
        var userRepository = scope.ServiceProvider.GetRequiredService<IAccountRepository>();
        var permissions = await userRepository.GetPermissionsByGuid(guid);
        
        if (permissions != null && permissions.Any(p => p == requirement.Permission))
        {
            context.Succeed(requirement);
        }
    }
}