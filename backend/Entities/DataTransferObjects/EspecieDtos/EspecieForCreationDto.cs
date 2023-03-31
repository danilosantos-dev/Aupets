using System.ComponentModel.DataAnnotations;

namespace Entities.DataTransferObjects
{
    public class EspecieForCreationDto
    {
        [Required(ErrorMessage = "Campo obrigatório: Nome")]
        [StringLength(60,ErrorMessage ="O Nome não pode ultrapassar 60 caracteres")]
        public string Nome { get; set; }
    }
}