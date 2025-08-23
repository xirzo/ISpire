namespace ISpire.Core.Errors;

public abstract record LoginResult
{
    public sealed record AccountNotFound : LoginResult;
    public sealed record WrongPassword: LoginResult;
    public sealed record Success(string Token) : LoginResult;
}