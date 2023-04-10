using Contracts;
using Entities;
using Entities.Models;

namespace Repository;
public class AtuacaoRepository : RepositoryBase<Atuacao>, IAtuacaoRepository
{
    public AtuacaoRepository(RepositoryContext repositoryContext) : base (repositoryContext)
    {
    }

     public IEnumerable<Atuacao> GetAllAtuacao()
    {
        return FindAll()
            .OrderBy(atua => atua.Nome)
            .ToList();
    }

    public Atuacao GetAtuacaoById(Int16 atuacaoId)
    {
        return FindByCondition(atua => atua.Id.Equals(atuacaoId))
            .FirstOrDefault();
    }

    public void CreateAtuacao(Atuacao atuacao)
    {
        Create(atuacao);
    }

    public void DeleteAtuacao(Atuacao atuacao)
    {
        Delete(atuacao);
    }

    public void UpdateAtuacao(Atuacao atuacao)
    {
        Update(atuacao);
    }
}
