using Entities.Models;

namespace Contracts;
public interface IUsuarioRepository : IRepositoryBase<Usuario>
{
    IEnumerable<Usuario> GetAllUsuarios();
    Usuario GetUsuarioById(Guid usuarioId);
    void CreateUsuario(Usuario usuario);
    void UpdateUsuario(Usuario usuario);
}