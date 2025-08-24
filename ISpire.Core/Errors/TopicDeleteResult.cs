namespace ISpire.Core.Errors;

public abstract record TopicDeleteResult
{
    public sealed record Success : TopicDeleteResult;
    public sealed record NotFound : TopicDeleteResult;
    public sealed record Failed : TopicDeleteResult;

}