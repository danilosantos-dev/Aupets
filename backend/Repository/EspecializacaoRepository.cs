using Contracts;
using Entities;
using Entities.Models;

namespace Repository;
public class EspecializacaoRepository : RepositoryBase<Especializacao>, IEspecializacaoRepository
{
    public EspecializacaoRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }

    public IEnumerable<Especializacao> GetAllEspecializacao()
    {
        return FindAll()
            .OrderBy(espe => espe.Nome)
            .ToList();
    }

 
}
