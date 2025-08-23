using ISpire.Core.Entities;
using ISpire.Core.Errors;

namespace ISpire.Core.Repositories;

public interface ISubjectRepository
{
    Task<Subject?> Add(string name, string url);

    Task<Subject?> FindByGuid(Guid guid);

    Task<Subject?> FindByName(string name);

    Task<SubjectDeleteResult> DeleteByGuid(Guid guid);
};