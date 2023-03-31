using Contracts;
using Entities;
using Entities.Models;

namespace Repository;
public class EspecieRepository : RepositoryBase<Especie>, IEspecieRepository
{
    public EspecieRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }

    public IEnumerable<Especie> GetAllEspecies()
    {
        return FindAll()
            .OrderBy(esp => esp.Nome)
            .ToList();
    }

     public Especie GetEspecieById(byte especieId)
    {
        return FindByCondition(especie => especie.Id.Equals(especieId))
            .FirstOrDefault();
    }
    public void CreateEspecie(Especie especie)
    {
        Create(especie);
    }

    public void DeleteEspecie(Especie especie)
    {
        Delete(especie);
    }
    
    public void UpdateEspecie(Especie especie)
    {
        Update(especie);
    }
}
