using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("Avaliacoes")]
    public class Avaliacoes
    {
        [Key]
        public int Id { get; set; }

        [StringLength(2000)]
        public string ReviewText { get; set; }

        [Required]
        public DateTime ReviewDate { get; set; }

        [StringLength(400)]
        public string Image { get; set; }

        [Required]
        public byte Rating { get; set; }

        [Required]
        public Guid UsuarioId { get; set; }

        [ForeignKey("UsuarioId")]
        public Usuario Usuario { get; set; }

        [Required]
        public int PrestadorId { get; set; }

        [ForeignKey("PrestadorId")]
        public Prestador Prestador { get; set; }
    }
}