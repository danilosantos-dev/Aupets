using Contracts;
using Entities;

namespace Repository;
public class RepositoryWrapper : IRepositoryWrapper
{
    private RepositoryContext _repoContext;
    private IAtuacaoPrestadorRepository _atuacaoPrestador;
    private IAtuacaoRepository _atuacao;
    private IAvaliacaoRepository _avaliacao;
    private IEspecializacaoPrestadorRepository _especializacaoPrestador;
    private IEspecializacaoRepository _especializacao;
    private IEspecieRepository _especie;
    private IPrestadorRepository _prestador;
    private IStatusRepository _status;
    private IUsuarioRepository _usuario;

    public IAtuacaoPrestadorRepository AtuacaoPrestador
    {
        get
        {
            if (_atuacaoPrestador == null)
            {
                _atuacaoPrestador = new AtuacaoPrestadorRepository(_repoContext);
            }

            return _atuacaoPrestador;
        }
    }

    public IAtuacaoRepository Atuacao
    {
        get
        {
            if (_atuacao == null)
            {
                _atuacao = new AtuacaoRepository(_repoContext);
            }

            return _atuacao;
        }
    }

    public IAvaliacaoRepository Avaliacao
    {
        get
        {
            if (_avaliacao == null)
            {
                _avaliacao = new AvaliacaoRepository(_repoContext);
            }

            return _avaliacao;
        }
    }

    public IEspecializacaoPrestadorRepository EspecializacaoPrestador
    {
        get
        {
            if (_especializacaoPrestador == null)
            {
                _especializacaoPrestador = new EspecializacaoPrestadorRepository(_repoContext);
            }

            return _especializacaoPrestador;
        }
    }

    public IEspecializacaoRepository Especializacao
    {
        get
        {
            if (_especializacao == null)
            {
                _especializacao = new EspecializacaoRepository(_repoContext);
            }

            return _especializacao;
        }
    }

    public IEspecieRepository Especie
    {
        get
        {
            if (_especie == null)
            {
                _especie = new EspecieRepository(_repoContext);
            }

            return _especie;
        }
    }

    public IPrestadorRepository Prestador
    {
        get
        {
            if (_prestador == null)
            {
                _prestador = new PrestadorRepository(_repoContext);
            }

            return _prestador;
        }
    }

    public IStatusRepository Status
    {
        get
        {
            if (_status == null)
            {
                _status = new StatusRepository(_repoContext);
            }

            return _status;
        }
    }

    public IUsuarioRepository Usuario
    {
        get
        {
            if (_usuario == null)
            {
                _usuario = new UsuarioRepository(_repoContext);
            }

            return _usuario;
        }
    }

    public void Save()
    {
        _repoContext.SaveChanges();
    }
}