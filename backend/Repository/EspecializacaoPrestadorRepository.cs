using Contracts;
using Entities;
using Entities.Models;

namespace Repository;
public class EspecializacaoPrestadorRepository : RepositoryBase<EspecializacaoPrestador>, IEspecializacaoPrestadorRepository
{
    public EspecializacaoPrestadorRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }

    public void CreateEspecializacaoPrestador(EspecializacaoPrestador especializacaoPrestador)
    {
        throw new NotImplementedException();
    }

    public void DeleteEspecializacaoPrestador(EspecializacaoPrestador especializacaoPrestador)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<EspecializacaoPrestador> GetEspecializacoes(short especializacaoId)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<EspecializacaoPrestador> GetEspecies(int especieId)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<EspecializacaoPrestador> GetPrestadores(int prestadorId)
    {
        throw new NotImplementedException();
    }
}