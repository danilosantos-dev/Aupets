using Contracts;
using Entities;
using Entities.Models;

namespace Repository;
public class StatusRepository : RepositoryBase<Status>, IStatusRepository
{
    public StatusRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }
    public IEnumerable<Status> GetAllStatus()
    {
        return FindAll()
            .OrderBy(sts => sts.Nome)
            .ToList();
    }

    public Status GetStatusById(int statusId)
    {
        return FindByCondition(status => status.Id.Equals(statusId))
            .FirstOrDefault();
    }
}
