using Contracts;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Entities.DataTransferObjects;

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

        [HttpGet("{id}")]
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
                    _logger.LogInfo($"Retornando o status com Id: {id}.")

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
    }
}