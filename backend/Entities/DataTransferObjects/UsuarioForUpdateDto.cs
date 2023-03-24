using System.ComponentModel.DataAnnotations;

namespace Entities.DataTransferObjects
{
    public class UsuarioForUpdateDto
    {

        [Required(ErrorMessage = "Campo obrigatório: Nome")]
        [StringLength(60, ErrorMessage = "O Nome não pode ter mais de 60 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo obrigatório : Senha")]
        [StringLength(200)]
        public string Senha { get; set; } 
        
        [Required(ErrorMessage = "Campo obrigatório: Imagem")]
        [StringLength(400)]
        public string Imagem { get; set; }
        
    }
}