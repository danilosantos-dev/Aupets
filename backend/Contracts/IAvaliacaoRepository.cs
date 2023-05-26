using Entities.Models;

namespace Contracts;
public interface IAvaliacaoRepository : IRepositoryBase<Avaliacoes>
{
    IEnumerable<Avaliacoes> GetAllAvaliacoes();
    Avaliacoes GetAvaliacaoById(int avaliacaoId);
    void CreateAvaliacao(Avaliacoes avaliacao);
    void UpdateAvaliacao(Avaliacoes avaliacao);
    void DeleteAvaliacao(Avaliacoes avaliacao);
}