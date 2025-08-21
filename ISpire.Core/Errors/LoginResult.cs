namespace ISpire.Core.Errors;

public abstract record LoginResult
{
    public record AccountNotFound : LoginResult;
    public record WrongPassword: LoginResult;
    public record Success(string Token) : LoginResult;
}