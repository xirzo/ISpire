namespace ISpire.Core.Entities;

public class Account
{
    public Guid Guid { get; set; }
    public required string Name { get; set; }
    public required string Email { get; set; }
    public required string PasswordHash { get; set; }
}