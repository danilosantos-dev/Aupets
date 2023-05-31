using System.ComponentModel.DataAnnotations;
using Entities.Models;

namespace Entities.DataTransferObjects;
public class EspecializacaoPrestadorForCreationDto
{
    [Required]
    [StringLength(255)]
    public string Descricao { get; set; }

    [Required]
    public int Especializacao { get; set; }

    [Required]
    public int Prestador { get; set; }

    [Required]
    public int Especie { get; set; }
}