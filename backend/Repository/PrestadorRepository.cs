using Contracts;
using Entities;
using Entities.Models;

namespace Repository;
public class PrestadorRepository : RepositoryBase<Prestador>, IPrestadorRepository
{
    public PrestadorRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }

     public IEnumerable<Prestador> GetAllPrestadores()
    {
         return FindAll()
            .OrderBy(prest => prest.NomeFantasia)
            .ToList();
    }

    public Prestador GetPrestadorById(int prestadorId)
    {
        return FindByCondition(prest => prest.Id.Equals(prestadorId))
            .FirstOrDefault();
    }

    public Prestador GetPrestadorDetailed(int prestaId)
    {
        return FindByCondition(presta => presta.Id.Equals(prestaId))
            .FirstOrDefault();
    }

    public void CreatePrestador(Prestador prestador)
    {
        Create(prestador);
    }

    public void UpdatePrestador(Prestador prestador)
    {
        Update(prestador);
    }
    
    public void DeletePrestador(Prestador prestador)
    {
        Delete(prestador);
    }

    
}
