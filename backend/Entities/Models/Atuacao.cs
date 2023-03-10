using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("Atuacao")]
    public class Atuacao
    {
        [Key]
        public Int16 Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Nome { get; set; }

        public ICollection<AtuacaoPrestador> Prestadores { get; set; }
    }
}