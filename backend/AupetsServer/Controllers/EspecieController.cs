using Contracts;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;


namespace AupetsServer.Controllers
{
    [ApiController]
    [Route("api/especie")]
    public class EspecieController : ControllerBase
    {
        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;
        private IMapper _mapper;

        public EspecieController(ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllEspecies()
        {
            try
            {
                var especie = _repository.Especie.GetAllEspecies();
                _logger.LogInfo($"Retornando todos as especies do banco de dados. ");

                var especieResult = _mapper.Map<IEnumerable<EspecieDto>>(especie);
                return Ok(especieResult);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Ocorreu um erro no método GetAllEspecies: {ex.Message}");
                return StatusCode(500, "Erro interno do Servidor");
            }
        }

        [HttpGet("{id}", Name = "EspecieById")]
        public IActionResult GetEspecieById(byte especieId)
        {
            try
            {
                var especie = _repository.Especie.GetEspecieById(especieId);

                if (especie is null)
                {
                    _logger.LogError($"Especie com Id: {especieId}, não encontrado.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Retornando o especie com Id: {especieId}.");

                    var especieResult = _mapper.Map<EspecieDto>(especie);
                    return Ok(especieResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Ocorreu um erro no metodo GetEspecieById: {ex.Message}");
                return StatusCode(500, "Erro Interno do Servidor");
            }
        }

        [HttpPost]
        public IActionResult CreateEspecie([FromBody] EspecieForCreationDto especie)
        {
            try
            {
                if (especie is null)
                {
                    _logger.LogError("Objeto Especie enviado está nulo.");
                    return BadRequest("Objeto Especie é nulo");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Objeto Especie enviado é inválido.");
                    return BadRequest("Objeto de modelo inválido");
                }

                var especieEntity = _mapper.Map<Especie>(especie);

                _repository.Especie.CreateEspecie(especieEntity);
                _repository.Save();

                var createdEspecie = _mapper.Map<EspecieDto>(especieEntity);

                return CreatedAtRoute("EspecieById", new { id = createdEspecie.Id }, createdEspecie);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Ocorreu um erro no metodo CreateEspecie: {ex.Message}");
                return StatusCode(500, "Erro Interno do Servidor");
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateEspecie(byte id, [FromBody] EspecieForUpdateDto especie)
        {
            try
            {
                if (especie is null)
                {
                    _logger.LogError("Objeto Especie enviado está nulo.");
                    return BadRequest("Objeto Especie é nulo");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Objeto Especie enviado é Invalido.");
                    return BadRequest("Objeto de modelo inválido");
                }

                var especieEntity = _repository.Especie.GetEspecieById(id);
                if (especieEntity is null)
                {
                    _logger.LogError($"Especie com Id: {id}, não encontrado.");
                    return NotFound();
                }

                _mapper.Map(especie, especieEntity);

                _repository.Especie.UpdateEspecie(especieEntity);
                _repository.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Ocorreu um erro no método UpdateEspecie: {ex.Message}");
                return StatusCode(500, "Erro Interno do Servidor");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEspecie(byte id)
        {
            try
            {
                var especie = _repository.Especie.GetEspecieById(id);
                if (especie == null)
                {
                    _logger.LogError($"Especie com Id: {id}, não encontrado.");
                    return NotFound();
                }
               
                _repository.Especie.DeleteEspecie(especie);
                _repository.Save();
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Ocorreu um erro no método DeleteEspecie: {ex.Message}");
                return StatusCode(500, "Erro Interno do Servidor");
            }
        }

    }
}