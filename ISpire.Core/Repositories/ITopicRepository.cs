using ISpire.Core.Entities;
using ISpire.Core.Errors;

namespace ISpire.Core.Repositories;

public interface ITopicRepository
{
    Task<Topic?> Add(string name, string description, string url, Guid subjectGuid, Subject subject);
    Task<Topic?> FindByGuid(Guid guid);
    Task<TopicDeleteResult> DeleteByGuid(Guid guid);
};