using Contracts;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;

namespace AupetsServer.Controllers;
[ApiController]
[Route("api/prestador")]
public class PrestadorController : ControllerBase
{
    private ILoggerManager _logger;
    private Contracts.IRepositoryWrapper _repository;
    private IMapper _mapper;

    public PrestadorController(ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper)
    {
        _logger = logger;
        _repository = repository;
        _mapper = mapper;
    }

    [HttpGet]

    public IActionResult GetAllPrestadores()
    {
        try
        {
            var prestador = _repository.Prestador.GetAllPrestadores();
            _logger.LogInfo($"Retornando todos os Prestadores do banco de dados. ");

            var prestResult = _mapper.Map<IEnumerable<PrestadorDto>>(prestador);
            return Ok(prestResult);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Ocorreu um erro no método GetAllPrestadores: {ex.Message}");
            return StatusCode(500, "Erro interno do Servidor");
        }
    }

    [HttpGet("{id}", Name = "GetPrestadorById")]
    public IActionResult GetPrestadorById(int id)
    {
        try
        {
            var prestador = _repository.Prestador.GetPrestadorById(id);

            if (prestador is null)
            {
                _logger.LogError($"Prestador com Id: {id}, não encontrado.");
                return NotFound();
            }
            else
            {
                _logger.LogInfo($"Retornando o prestador com Id: {id}.");

                var prestResult = _mapper.Map<PrestadorDto>(prestador);
                return Ok(prestResult);
            }
        }
        catch (Exception ex)
        {
            _logger.LogError($"Ocorreu um erro no metodo GetPrestadorById: {ex.Message}");
            return StatusCode(500, "Erro Interno do Servidor");
        }
    }

    [HttpPost]
    public IActionResult CreatePrestador([FromForm] PrestadorForCreationDto prestador)
    {
        try
        {
            if (prestador is null)
            {
                _logger.LogError("Objeto Prestador enviado está nulo.");
                return BadRequest("Objeto Prestador é nulo");
            }

            if (!ModelState.IsValid)
            {
                _logger.LogError("Objeto Prestador enviado é inválido.");
                return BadRequest("Objeto de modelo inválido");
            }

            var prestadorEntity = _mapper.Map<Prestador>(prestador);

            _repository.Prestador.CreatePrestadorWithImagem(prestadorEntity, prestador.Imagem?.OpenReadStream());
            _repository.Save();

            var usuarioId = Guid.Parse(prestador.UsuarioId);
            prestadorEntity.Usuario = _repository.Usuario.GetUsuarioById(usuarioId);

            prestadorEntity.Status = _repository.Status.GetStatusById(prestador.StatusId);

            var createdPrestador = _mapper.Map<PrestadorDto>(prestadorEntity);

            return CreatedAtRoute("GetPrestadorById", new { id = createdPrestador.Id }, createdPrestador);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Ocorreu um erro no metodo CreatePrestador: {ex.Message}");
            return StatusCode(500, "Erro Interno do Servidor");
        }
    }


    [HttpPut("{id}")]
    public IActionResult UpdatePrestador(int id, [FromForm] PrestadorForUpdateDto prestador)
    {
        try
        {
            if (prestador is null)
            {
                _logger.LogError("Objeto Prestador enviado está nulo.");
                return BadRequest("Objeto Prestador é nulo");
            }

            if (!ModelState.IsValid)
            {
                _logger.LogError("Objeto Prestador enviado é Invalido.");
                return BadRequest("Objeto de modelo inválido");
            }

            var prestEntity = _repository.Prestador.GetPrestadorById(id);
            if (prestEntity is null)
            {
                _logger.LogError($"Prestador com Id: {id}, não encontrado.");
                return NotFound();
            }

            _mapper.Map(prestador, prestEntity);

            _repository.Prestador.UpdatePrestadorWithImagem(prestEntity, prestador.Imagem?.OpenReadStream());
            _repository.Save();

            return NoContent();
        }
        catch (Exception ex)
        {
            _logger.LogError($"Ocorreu um erro no método UpdatePrestador: {ex.Message}");
            return StatusCode(500, "Erro Interno do Servidor");
        }
    }

    [HttpDelete("{id}")]
    public IActionResult DeletePrestador(int id)
    {
        try
        {
            var prestador = _repository.Prestador.GetPrestadorById(id);
            if (prestador == null)
            {
                _logger.LogError($"Prestador com Id: {id}, não encontrado.");
                return NotFound();
            }

            _repository.Prestador.DeletePrestador(prestador);
            _repository.Save();
            return NoContent();
        }
        catch (Exception ex)
        {
            _logger.LogError($"Ocorreu um erro no método DeletePrestador: {ex.Message}");
            return StatusCode(500, "Erro Interno do Servidor");
        }
    }

    [HttpGet("details/{id}", Name = "GetPrestadorDetailed")]
    public IActionResult GetPrestadorDetailed(int id)
    {
        try
        {
            var prestador = _repository.Prestador.GetPrestadorById(id);

            if (prestador is null)
            {
                _logger.LogError($"Prestador com Id: {id}, não encontrado.");
                return NotFound();
            }
            else
            {
                _logger.LogInfo($"Retornando o prestador com Id: {id}.");

                prestador.Usuario = _repository.Usuario.GetUsuarioById(prestador.UsuarioId);

                prestador.Status = _repository.Status.GetStatusById(prestador.StatusId);

                var prestaResult = _mapper.Map<PrestadorDto>(prestador);
                return Ok(prestaResult);
            }
        }
        catch (Exception ex)
        {
            _logger.LogError($"Ocorreu um erro no metodo GetPrestadorById: {ex.Message}");
            return StatusCode(500, "Erro Interno do Servidor");
        }
    }
}