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

    public Especializacao GetEspecializacaoById(Int16 especializacaoId)
    {
        return FindByCondition(especializacao => especializacao.Id.Equals(especializacaoId))
            .FirstOrDefault();
    }

    public void CreateEspecializacao(Especializacao especializacao)
    {
        Create(especializacao);
    }

    public void DeleteEspecializacao(Especializacao especializacao)
    {
        Delete(especializacao);
    }

    public void UpdateEspecializacao(Especializacao especializacao)
    {
        Update(especializacao);
    }
}
