using Entities.Models;

namespace Contracts;
public interface IEspecializacaoPrestadorRepository : IRepositoryBase<EspecializacaoPrestador>
{
    IEnumerable<EspecializacaoPrestador>GetPrestadores(int prestadorId);
    IEnumerable<EspecializacaoPrestador>GetEspecializacoes(Int16 especializacaoId);
    IEnumerable<EspecializacaoPrestador>GetEspecies(int especieId);
    void CreateEspecializacaoPrestador(EspecializacaoPrestador especializacaoPrestador);
    void DeleteEspecializacaoPrestador(EspecializacaoPrestador especializacaoPrestador);
}