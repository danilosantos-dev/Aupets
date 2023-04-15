using Entities.Models;

namespace Contracts;
public interface IPrestadorRepository : IRepositoryBase<Prestador>
{
    IEnumerable<Prestador> GetAllPrestadores();
    Prestador GetPrestadorById(int prestadorId);
    void CreatePrestador(Prestador prestador);
    void UpdatePrestador(Prestador prestador);
    void DeletePrestador(Prestador prestador);
}