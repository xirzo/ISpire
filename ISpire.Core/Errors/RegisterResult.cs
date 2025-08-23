using ISpire.Core.Entities;

namespace ISpire.Core.Errors;

public abstract record RegisterResult
{
    public sealed record AlreadyExists : RegisterResult;
    public sealed record WrongEmailPattern: RegisterResult;
    public sealed record RepositoryAddFailed: RegisterResult;
    public sealed record Success(Account Account) : RegisterResult;
    public sealed record ForbiddenCharactersInName : RegisterResult;
}