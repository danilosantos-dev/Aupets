using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("Especie")]
    public class Especie
    {
        [Key]
        public int Id { get; set; }

        [StringLength(20)]
        public string Nome { get; set; }
    }
}