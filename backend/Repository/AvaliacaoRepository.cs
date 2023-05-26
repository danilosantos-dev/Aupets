using Contracts;
using Entities;
using Entities.Models;

namespace Repository;
public class AvaliacaoRepository : RepositoryBase<Avaliacoes>, IAvaliacaoRepository
{
    public AvaliacaoRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }

    public IEnumerable<Avaliacoes> GetAllAvaliacoes()
    {
        return FindAll().ToList();
    }

    public Avaliacoes GetAvaliacaoById(int avaliacaoId)
    {
       return FindByCondition(aval => aval.Id.Equals(avaliacaoId))
            .FirstOrDefault();
    }

    public void CreateAvaliacao(Avaliacoes avaliacao)
    {
        Create(avaliacao);
    }

    public void DeleteAvaliacao(Avaliacoes avaliacao)
    {
        Delete(avaliacao);
    }

    public void UpdateAvaliacao(Avaliacoes avaliacao)
    {
        Update(avaliacao);
    }
}
