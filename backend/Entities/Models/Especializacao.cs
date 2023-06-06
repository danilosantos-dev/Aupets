using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models;

[Table("Especializacao")]
public class Especializacao
{
    [Key]
    public Int16 Id { get; set; }

    [Required]
    [StringLength(255)]
    public string Nome { get; set; }
}