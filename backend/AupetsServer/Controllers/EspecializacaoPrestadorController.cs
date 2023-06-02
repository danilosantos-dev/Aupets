using Contracts;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;

namespace AupetsServer.Controllers;

[ApiController]
[Route("api/EspecializacaoPrestador")]
public class EspecializacaoPrestadorController : ControllerBase
{
    private ILoggerManager _logger;
    private IRepositoryWrapper _repository;
    private IMapper _mapper;

    public EspecializacaoPrestadorController(ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper)
    {
        _logger = logger;
        _repository = repository;
        _mapper = mapper;
    }

    [HttpGet("{id}", Name = "Especializacoes")]
    public IActionResult GetEspecializacoes(Int16 especializacaoId)
    {
        try
        {
            var especializacao = _repository.EspecializacaoPrestador.GetEspecializacoes(especializacaoId);

            if (especializacao is null)
            {
                _logger.LogError($"Especializacao com Id: {especializacaoId}, não encontrado.");
                return NotFound();
            }
            else
            {
                _logger.LogInfo($"Retornando a especializacao com Id: {especializacaoId}.");

                var especialiResult = _mapper.Map<EspecializacaoPrestadorDto>(especializacao);
                return Ok(especialiResult);
            }
        }
        catch (Exception ex)
        {
            _logger.LogError($"Ocorreu um erro no metodo GetEspecializacoes: {ex.Message}");
            return StatusCode(500, "Erro Interno do Servidor");
        }
    }

    [HttpGet("{id}", Name = " GetPrestadorById ")]
    public IActionResult GetPrestadores(int prestadorId)
    {
        try
        {
            var prestador = _repository.EspecializacaoPrestador.GetPrestadores(prestadorId);

            if (prestador is null)
            {
                _logger.LogError($"Prestador com Id: {prestadorId}, não encontrado.");
                return NotFound();
            }
            else
            {
                _logger.LogInfo($"Retornando o especie com Id: {prestadorId}.");

                var prestResult = _mapper.Map<EspecializacaoPrestadorDto>(prestador);
                return Ok(prestResult);
            }
        }
        catch (Exception ex)
        {
            _logger.LogError($"Ocorreu um erro no metodo GetPrestadores: {ex.Message}");
            return StatusCode(500, "Erro Interno do Servidor");
        }
    }

    [HttpGet("{id}", Name = "EspecieById")]
    public IActionResult GetEspecies(byte especieId)
    {
        try
        {
            var especie = _repository.EspecializacaoPrestador.GetEspecies(especieId);

            if (especie is null)
            {
                _logger.LogError($"Especie com Id: {especieId}, não encontrado.");
                return NotFound();
            }
            else
            {
                _logger.LogInfo($"Retornando o especie com Id: {especieId}.");

                var especieResult = _mapper.Map<EspecializacaoPrestadorDto>(especie);
                return Ok(especieResult);
            }
        }
        catch (Exception ex)
        {
            _logger.LogError($"Ocorreu um erro no metodo GetEspecies: {ex.Message}");
            return StatusCode(500, "Erro Interno do Servidor");
        }
    }

    [HttpPost]
    public IActionResult CreateEspecializacaoPrestador([FromBody] EspecializacaoPrestadorForCreationDto especializacaoPrestador)
    {
        try
        {
            if (especializacaoPrestador is null)
            {
                _logger.LogError("Objeto Especializacao Prestador enviado está nulo.");
                return BadRequest("Objeto Especializacao Prestador é nulo");
            }

            if (!ModelState.IsValid)
            {
                _logger.LogError("Objeto Especializacao Prestador enviado é inválido.");
                return BadRequest("Objeto de modelo inválido");
            }

            var espePrestEntity = _mapper.Map<EspecializacaoPrestador>(especializacaoPrestador);

            _repository.EspecializacaoPrestador.CreateEspecializacaoPrestador(espePrestEntity);
            _repository.Save();

            var createdEspecializacao = _mapper.Map<EspecializacaoDto>(espePrestEntity);

            return Ok();
        }
        catch (Exception ex)
        {
            _logger.LogError($"Ocorreu um erro no metodo CreateEspecializacaoPrestador: {ex.Message}");
            return StatusCode(500, "Erro Interno do Servidor");
        }
    }
}