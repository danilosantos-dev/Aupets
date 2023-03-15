using Contracts;
using Microsoft.AspNetCore.Mvc;

namespace AupetsServer.Controllers
{
    [ApiController]
    [Route("api/status")]
    public class StatusController : ControllerBase
    {
        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;

        public StatusController(ILoggerManager logger, IRepositoryWrapper repository)
        {
            _logger = logger;
            _repository = repository;
        }
        [HttpGet]
        public IActionResult GetAllStatus()
        {
            try
            {
                var status = _repository.Status.GetAllStatus();
                _logger.LogInfo($"Retornando todos os status do banco de dados. ");
                return Ok(status);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Ocorreu um erro no método GetAllStatus: {ex.Message}");
                return StatusCode(500, "Erro interno do Servidor");
            }
        }

        
    }
}