using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("AtuacaoPrestador")]
    public class AtuacaoPrestador
    {
        [Key, Column(Order = 1)]
        public int PrestadorId { get; set; }
        [ForeignKey("PrestadorId")]
        public Prestador Prestador { get; set; }

        [Key, Column(Order = 2)]
        public Int16 AtuacaoId { get; set; }
        [ForeignKey("AtuacaoId")]
        public Atuacao Atuacao { get; set; }
    }
}