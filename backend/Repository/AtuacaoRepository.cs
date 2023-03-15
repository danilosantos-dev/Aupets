using Contracts;
using Entities;
using Entities.Models;

namespace Repository;
public class AtuacaoRepository : RepositoryBase<Atuacao>, IAtuacaoRepository
{
    public AtuacaoRepository(RepositoryContext repositoryContext) : base (repositoryContext)
    {
    }
}
