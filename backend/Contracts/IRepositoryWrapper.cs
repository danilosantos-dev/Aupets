
namespace Contracts;
public interface IRepositoryWrapper
{
    IAtuacaoPrestadorRepository AtuacaoPrestador { get; }
    IAtuacaoRepository Atuacao { get; }
    IAvaliacaoRepository Avaliacao { get; }
    IEspecializacaoPrestadorRepository EspecializacaoPrestador { get; }
    IEspecializacaoRepository Especializacao { get; }
    IEspecieRepository Especie { get; }
    IPrestadorRepository Prestador { get; }
    IStatusRepository Status { get; }
    IUsuarioRepository Usuario { get; }

    void Save();
}