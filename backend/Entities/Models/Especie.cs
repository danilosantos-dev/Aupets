using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("Especie")]
    public class Especie
    {
        [Key]
        public byte Id { get; set; }

        [Required]
        [StringLength(30)]
        public string Nome { get; set; }
    }
}