using Contracts;
using Entities;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using System.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;

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
        usuario.Senha = hash.HashPassword(usuario, usuario.Senha);
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

    public Usuario GetByEmail(string email)
    {
        return FindByCondition(usuario => usuario.Email.Equals(email))
            .FirstOrDefault();
    }

    public string Login(string email, string senha)
    {
        var usuario = GetByEmail(email);
        if(usuario == null)
        {
            return null;
        }
        var hash = new PasswordHasher<Usuario>();
        return hash.VerifyHashedPassword(usuario, usuario.Senha, senha) == PasswordVerificationResult.Success ? usuario.Id.ToString() : null;
    }
}