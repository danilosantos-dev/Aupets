using Contracts;
using Entities;
using Entities.Models;

namespace Repository;
public class EspecializacaoPrestadorRepository : RepositoryBase<EspecializacaoPrestador>, IEspecializacaoPrestadorRepository
{
    public EspecializacaoPrestadorRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }
}