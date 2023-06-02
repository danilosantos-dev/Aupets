using System.ComponentModel.DataAnnotations;
using Entities.Models;

namespace Entities.DataTransferObjects;
public class EspecializacaoPrestadorForCreationDto
{
    public string Descricao { get; set; }

    public Int16 Especializacao { get; set; }

    public int Prestador { get; set; }

    public int Especie { get; set; }
}