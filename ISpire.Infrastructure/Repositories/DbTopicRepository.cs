using ISpire.Core.Entities;
using ISpire.Core.Repositories;
using ISpire.Core.Errors;
using ISpire.Infrastructure.Contexts;

public class DbTopicRepository : ITopicRepository
{
    private readonly AppDbContext _dbContext;

    public DbTopicRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Topic?> Add(string name, string description, string url, Guid subjectGuid, Subject subject)
    {
        var topic = new Topic
        {
            Guid = Guid.NewGuid(),
            Name = name,
            Description = description,
            Url = url,
            SubjectGuid = subjectGuid,
            Subject = subject,
        };

        await _dbContext.Topics.AddAsync(topic);
        try
        {
            await _dbContext.SaveChangesAsync();
            return topic;
        }
        catch (Exception e)
        {
            return null;
        }

    }

    public async Task<Topic?> FindByGuid(Guid guid)
    {
        return await _dbContext.Topics.FirstOrDefaultAsync(x => x.Guid == guid);
    }

    public async Task<Topic?> FindBySubjectGuidAndName(Guid subjectGuid, string name)
    {
        return await _dbContext.Topics.FirstOrDefaultAsync(x => SubjectGuid == subjectGuid && x.Name == name);
    }

    public async Task<TopicDeleteResult> DeleteByGuid(Guid guid)
    {
        var topic = _dbContext.Topics.FirstOrDefaultAsync(x => x.Guid == guid);

        if (topic is null)
        {
            return new TopicDeleteResult.NotFound();
        }

        _dbContext.Topics.Remove(topic);

        try
        {
            await _dbContext.SaveChangesAsync();
            return new TopicDeleteResult.Success();
        }
        catch (Exception e)
        {
            return new TopicDeleteResult.Failed();
        }
    }
}