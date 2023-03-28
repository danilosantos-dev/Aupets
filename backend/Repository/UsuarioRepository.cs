using Contracts;
using Entities;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
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
        var hash = new PasswordHasher<Usuario>();
        usuario.Senha = hash.HashPassword(null, usuario.Senha);
        usuario.SenhaHash = hash.GetHashCode().ToString();
        Create(usuario);
    }

    public void UpdateUsuario(Usuario usuario)
    {
        Update(usuario);
    }

    public void DeleteUsuario(Usuario usuario)
    {
        Delete(usuario);
    }

}