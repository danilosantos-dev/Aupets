using Contracts;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository;
public class UsuarioRepository : RepositoryBase<Usuario>, IUsuarioRepository
{
    public UsuarioRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }

    public IEnumerable<Usuario> GetAllUsuarios()
    {
        return FindAll()
            .OrderBy(user => user.Nome)
            .ToList();
    }

    public Usuario GetUsuarioById(Guid usuarioId)
    {
        return FindByCondition(usuario => usuario.Id.Equals(usuarioId))
            .FirstOrDefault();
    }

    public void CreateUsuario(Usuario usuario)
    {
        Create(usuario);
    }

    public void UpdateUsuario(Usuario usuario)
    {
        Update(usuario);
    }
}