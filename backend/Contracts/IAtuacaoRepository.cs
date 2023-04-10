using Entities.Models;

namespace Contracts;
public interface IAtuacaoRepository : IRepositoryBase<Atuacao>
{

    IEnumerable<Atuacao> GetAllAtuacao();
    Atuacao GetAtuacaoById(Int16 atuacaoId);
    void CreateAtuacao(Atuacao atuacao);
    void UpdateAtuacao(Atuacao atuacao);
    void DeleteAtuacao(Atuacao atuacao);
    
}