

namespace Entities.DataTransferObjects;
public class UsuarioDto
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public string Senha { get; set; }
    public string SenhaHash { get; set; }
    public string Email { get; set; }
    public string Imagem { get; set; }
    public bool EAdmin { get; set; }
}