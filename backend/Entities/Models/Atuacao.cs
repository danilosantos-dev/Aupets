using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("Atuacao")]
    public class Atuacao
    {
        [Key]
        public int Id { get; set; }

        [StringLength(255)]
        public string Nome { get; set; }
    }
}