using ISpire.Core.Entities;

namespace ISpire.Core.Errors;

public abstract record RegisterResult
{
    public record AlreadyExists : RegisterResult;
    public record WrongEmailPattern: RegisterResult;
    public record RepositoryAddFailed: RegisterResult;
    public record Success(Account Account) : RegisterResult;
    public record ForbiddenCharactersInName : RegisterResult;
}