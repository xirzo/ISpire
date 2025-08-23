using ISpire.Core.Attributes;

namespace ISpire.Core.Entities;

public class AccountPermission
{
    public required Guid Guid { get; set; }
    [ValidPermissionName]
    public required string PermissionName { get; set; }
    public required Guid AccountGuid{ get; set; }
    public required Account Account { get; set; }
}