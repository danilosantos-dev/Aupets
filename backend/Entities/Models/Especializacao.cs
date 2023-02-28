using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("Especializacao")]
    public class Especializacao
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public int Nome { get; set; }
    }
}