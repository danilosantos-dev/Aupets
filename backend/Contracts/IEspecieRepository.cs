using Entities.Models;

namespace Contracts;
public interface IEspecieRepository : IRepositoryBase<Especie>
{

    IEnumerable<Especie> GetAllEspecies();
}