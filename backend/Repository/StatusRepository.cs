using Contracts;
using Entities;
using Entities.Models;

namespace Repository;
public class StatusRepository : RepositoryBase<Status>, IStatusRepository
{
    public StatusRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }
}
