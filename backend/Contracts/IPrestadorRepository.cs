using Entities.Models;
using Microsoft.AspNetCore.Http;

namespace Contracts;
public interface IPrestadorRepository : IRepositoryBase<Prestador>
{
    IEnumerable<Prestador> GetAllPrestadores();
    Prestador GetPrestadorById(int prestadorId);
    Prestador GetPrestadorDetailed(int prestaId);
    void CreatePrestador(Prestador prestador);
    void CreatePrestadorWithImagem(Prestador prestador, IFormFile imagem);
    void UpdatePrestador(Prestador prestador);
    void UpdatePrestadorWithImagem(Prestador prestador, IFormFile imagem);
    void DeletePrestador(Prestador prestador);
}