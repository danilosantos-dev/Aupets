using Entities.Models;

namespace Contracts;
public interface IEspecializacaoPrestadorRepository : IRepositoryBase<EspecializacaoPrestador>
{
    IEnumerable<Prestador>GetPrestadores(int prestadorId);
    IEnumerable<Especializacao>GetEspecializacoes(Int16 especializacaoId);
    IEnumerable<Especie>GetEspecies(int especieId);
}