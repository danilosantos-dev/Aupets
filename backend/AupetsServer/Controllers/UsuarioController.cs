using Contracts;
using Microsoft.AspNetCore.Mvc;


namespace AupetsServer.Controllers
{
    [ApiController]
    [Route("api/usuario")]
    public class UsuarioController : ControllerBase
    {
        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;

        public UsuarioController(ILoggerManager logger, IRepositoryWrapper repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetAllUsuarios()
        {
            try
            {
                var usuarios = _repository.Usuario.GetAllUsuarios();
                _logger.LogInfo($"Retornando todos os usuarios do banco de dados. ");
                return Ok(usuarios);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Ocorreu um erro no método GetAllUsuarios: {ex.Message}");
                return StatusCode(500, "Erro interno do Servidor");
            }
        }

     
    }
}