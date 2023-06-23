using Entities.Models;

namespace Contracts;
public interface IPrestadorRepository : IRepositoryBase<Prestador>
{
    IEnumerable<Prestador> GetAllPrestadores();
    Prestador GetPrestadorById(int prestadorId);
    Prestador GetPrestadorDetailed(int prestaId);
    void CreatePrestador(Prestador prestador);
    void CreatePrestadorWithImagem(Prestador prestador, Stream imagem);
    void UpdatePrestador(Prestador prestador);
    void UpdatePrestadorWithImagem(Prestador prestador, Stream imagem);
    void DeletePrestador(Prestador prestador);
}