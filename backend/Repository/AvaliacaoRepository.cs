using Contracts;
using Entities;
using Entities.Models;

namespace Repository;
public class AvaliacaoRepository : RepositoryBase<Avaliacoes>, IAvaliacaoRepository
{
    public AvaliacaoRepository(RepositoryContext repositoryContext) : base (repositoryContext)
    {
    }
}
