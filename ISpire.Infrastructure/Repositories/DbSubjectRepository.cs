using ISpire.Core.Repositories;
using ISpire.Core.Entities;
using ISpire.Core.Errors;
using ISpire.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace ISpire.Infrastructure.Repositories;

public class DbSubjectRepository : ISubjectRepository
{
    private readonly AppDbContext _dbContext;

    public DbSubjectRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Subject?> Add(string name, string url)
    {
        var subject = new Subject
        {
            Guid = Guid.NewGuid(),
            Name = name,
            Url = url,
        };

        await _dbContext.Subjects.AddAsync(subject);
        
        try
        {
            await _dbContext.SaveChangesAsync();
            return subject;
        }
        catch (Exception e)
        {
            return null;
        }
    }

    public async Task<Subject?> FindByGuid(Guid guid)
    {
        return await _dbContext.Subjects.FirstOrDefaultAsync(x => x.Guid == guid);
    }

    public async Task<SubjectDeleteResult> DeleteByGuid(Guid guid)
    {
        var subject = await _dbContext.Subjects.FirstOrDefaultAsync(x => x.Guid == guid);

        if (subject is null)
        {
            return new SubjectDeleteResult.NotFound();
        }

        _dbContext.Subjects.Remove(subject);

        try
        {
            await _dbContext.SaveChangesAsync();
            return new SubjectDeleteResult.Success();
        }
        catch (Exception e)
        {
            return new SubjectDeleteResult.Failed();
        }
    }
}