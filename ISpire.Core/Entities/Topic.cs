namespace ISpire.Core.Entities;

public class Topic
{
    public required Guid Guid { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required string Url { get; set; }
    public required Guid SubjectGuid { get; set; }
    public required Subject Subject { get; set; }
}