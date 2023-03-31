using Contracts;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;

namespace AupetsServer.Controllers
{
    [ApiController]
    [Route("api/status")]
    public class StatusController : ControllerBase
    {
        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;
        private IMapper _mapper;

        public StatusController(ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetAllStatus()
        {
            try
            {
                var status = _repository.Status.GetAllStatus();
                _logger.LogInfo($"Retornando todos os status do banco de dados. ");

                var statusResult = _mapper.Map<IEnumerable<StatusDto>>(status);
                return Ok(statusResult);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Ocorreu um erro no método GetAllStatus: {ex.Message}");
                return StatusCode(500, "Erro interno do Servidor");
            }
        }

        [HttpGet("{id}", Name = "StatusById")]
        public IActionResult GetStatusById(int id)
        {
            try
            {
                var status = _repository.Status.GetStatusById(id);

                if (status is null)
                {
                    _logger.LogError($"Status com Id: {id}, não encontrado.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Retornando o status com Id: {id}.");

                    var statusResult = _mapper.Map<StatusDto>(status);
                    return Ok(statusResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Ocorreu um erro no mpetodo GetStatusById: {ex.Message}");
                return StatusCode(500, "Erro Interno do Servidor");
            }
        }

        [HttpPost]
        public IActionResult CreateStatus([FromBody] Status status)
        {
            try
            {
                if (status is null)
                {
                    _logger.LogError("Objeto Status enviado está nulo.");
                    return BadRequest("Objeto Status é nulo");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Objeto Status enviado é inválido.");
                    return BadRequest("Objeto de modelo inválido");
                }

                var statusEntity = _mapper.Map<Status>(status);

                _repository.Status.CreateStatus(statusEntity);
                _repository.Save();

                var createdStatus = _mapper.Map<StatusDto>(statusEntity);

                return CreatedAtRoute("StatusById", new { id = createdStatus.Id }, createdStatus);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Ocorreu um erro no metodo CreateStatus: {ex.Message}");
                return StatusCode(500, "Erro Interno do Servidor");
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateStatus(int id, [FromBody] StatusForUpdateDto status)
        {
            try
            {
                if (status is null)
                {
                    _logger.LogError("Objeto Status enviado está nulo.");
                    return BadRequest("Objeto Status é nulo");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Objeto Status enviado é Invalido.");
                    return BadRequest("Objeto de modelo inválido");
                }

                var statusEntity = _repository.Status.GetStatusById(id);
                if (statusEntity is null)
                {
                    _logger.LogError($"Status com Id: {id}, não encontrado.");
                    return NotFound();
                }

                _mapper.Map(status, statusEntity);

                _repository.Status.UpdateStatus(statusEntity);
                _repository.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Ocorreu um erro no método UpdateStatus: {ex.Message}");
                return StatusCode(500, "Erro Interno do Servidor");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteStatus(int id)
        {
            try
            {
                var status = _repository.Status.GetStatusById(id);
                if (status == null)
                {
                    _logger.LogError($"Status com Id: {id}, não encontrado.");
                    return NotFound();
                }
               
                _repository.Status.DeleteStatus(status);
                _repository.Save();
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Ocorreu um erro no método DeleteStatus: {ex.Message}");
                return StatusCode(500, "Erro Interno do Servidor");
            }
        }
    }
}