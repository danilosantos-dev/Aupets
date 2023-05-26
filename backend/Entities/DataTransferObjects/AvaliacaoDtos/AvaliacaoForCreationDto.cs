using System.ComponentModel.DataAnnotations;


namespace Entities.DataTransferObjects
{
    public class AvaliacaoForCreationDto
    {
        [Required (ErrorMessage="Campo obrigatório: ReviewText")]
        [StringLength(2000, ErrorMessage ="A avaliação não pode ultrapassar 2000 caracteres")]
        public string ReviewText { get; set; }

        [StringLength(400)]
        public string Image { get; set; }

        [Required(ErrorMessage ="Campo obrigatório: Rating")]
        public byte Rating { get; set; }

    }
}