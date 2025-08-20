namespace ISpire.Web.Dtos;

public class RegisterDto 
{
    public required string Name { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
}