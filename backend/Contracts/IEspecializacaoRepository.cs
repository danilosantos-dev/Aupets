using System;
using Entities.Models;

namespace Contracts;
public interface IEspecializacaoRepository : IRepositoryBase<Especializacao>
{
    IEnumerable<Especializacao> GetAllEspecializacao();
    Especializacao GetEspecializacaoById(Int16 especializacaoId);
    void CreateEspecializacao(Especializacao especializacao);
    void UpdateEspecializacao(Especializacao especializacao);
    void DeleteEspecializacao(Especializacao especializacao);
}