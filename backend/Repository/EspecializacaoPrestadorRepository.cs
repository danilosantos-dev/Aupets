using Contracts;
using Entities;
using Entities.Models;

namespace Repository;
public class EspecializacaoPrestadorRepository : RepositoryBase<EspecializacaoPrestador>, IEspecializacaoPrestadorRepository
{
    public EspecializacaoPrestadorRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }

    public IEnumerable<Especializacao> GetEspecializacoes(short especializacaoId)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Especie> GetEspecies(int especieId)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Prestador> GetPrestadores(int prestadorId)
    {
        throw new NotImplementedException();
    }
}