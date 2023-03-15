using Contracts;
using Entities;
using Entities.Models;

namespace Repository;
public class PrestadorRepository : RepositoryBase<Prestador>, IPrestadorRepository
{
    public PrestadorRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }
}
