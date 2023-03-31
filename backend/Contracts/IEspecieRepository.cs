using Entities.Models;

namespace Contracts;
public interface IEspecieRepository : IRepositoryBase<Especie>
{
    IEnumerable<Especie> GetAllEspecies();
    Especie GetEspecieById(byte especieId );
    void CreateEspecie(Especie especie);
    void UpdateEspecie(Especie especie);
    void DeleteEspecie(Especie especie);
}