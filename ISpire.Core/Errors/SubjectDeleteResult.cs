namespace ISpire.Core.Errors;

public abstract record SubjectDeleteResult
{
    public sealed record Success : SubjectDeleteResult;
    public sealed record NotFound : SubjectDeleteResult;
    public sealed record Failed : SubjectDeleteResult;

}