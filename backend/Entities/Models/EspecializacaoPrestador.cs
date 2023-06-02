using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models;
[Table("EspecializacaoPrestador")]
public class EspecializacaoPrestador
{
    [Key, Column(Order = 1)]
    public int PrestadorId { get; set; }
    [ForeignKey("PrestadorId")]
    public Prestador Prestador { get; set; }

    [Key, Column(Order = 2)]
    public Int16 EspecializacaoId { get; set; }
    [ForeignKey("EspecializacaoId")]
    public Especializacao Especializacao { get; set; }

    [Required]
    [StringLength(255)]
    public string Descricao { get; set; }

    [Required]
    public byte EspecieId { get; set; }

    [ForeignKey("EspecieId")]
    public Especie Especie { get; set; }
}