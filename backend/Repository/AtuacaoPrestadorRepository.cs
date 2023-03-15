using Contracts;
using Entities;
using Entities.Models;

namespace Repository;
public class AtuacaoPrestadorRepository : RepositoryBase<AtuacaoPrestador>, IAtuacaoPrestadorRepository
{
    public AtuacaoPrestadorRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }
}
