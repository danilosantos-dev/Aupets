using Contracts;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Entities.DataTransferObjects;


namespace AupetsServer.Controllers
{
    [ApiController]
    [Route("api/usuario")]
    public class UsuarioController : ControllerBase
    {
        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;
        private IMapper _mapper;

        public UsuarioController(ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllUsuarios()
        {
            try
            {
                var usuarios = _repository.Usuario.GetAllUsuarios();
                _logger.LogInfo($"Retornando todos os usuarios do banco de dados. ");

                var usuarioResult = _mapper.Map<IEnumerable<UsuarioDto>>(usuarios);
                return Ok(usuarioResult);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Ocorreu um erro no método GetAllUsuarios: {ex.Message}");
                return StatusCode(500, "Erro interno do Servidor");
            }
        }

        
        
     
    }
}

