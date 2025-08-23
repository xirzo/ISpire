namespace ISpire.Core.Entities;

public class Account
{
    public required Guid Guid { get; set; }
    public required string Name { get; set; }
    public required string Email { get; set; }
    public required string PasswordHash { get; set; }
    public ICollection<AccountPermission> AccountPermissions { get; set; }  = new  List<AccountPermission>();
}