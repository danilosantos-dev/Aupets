using Entities.Models;

namespace Entities.DataTransferObjects;
public class EspecializacaoPrestadorDto
{
    public string descricao { get; set; }
    public ICollection<Especializacao> Especializacoes { get; set; }
    public ICollection<Prestador> Prestadores { get; set; }
    public ICollection<Especie> Especies { get; set; }
}