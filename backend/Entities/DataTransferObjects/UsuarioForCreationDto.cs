using System.ComponentModel.DataAnnotations;

namespace Entities.DataTransferObjects
{
    public class UsuarioForCreationDto
    {
        [Required(ErrorMessage = "Campo obrigatório: Nome")]
        [StringLength(60,ErrorMessage ="O Nome não pode ultrapassar 60 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage ="Campo obrigatório: Senha")]
        [StringLength(8, ErrorMessage ="A Senha não pode ultrapassar 8 caracteres")]
        public string Senha { get; set; }

        [Required(ErrorMessage = "Campo obrigatório: Email")]
        [EmailAddress(ErrorMessage = "Digite um email válido")]
        [StringLength(30, ErrorMessage ="O email deve ter no maximo 30 caracteres")]
        public string Email { get; set; }
        public string Imagem { get; set; }
    }
}