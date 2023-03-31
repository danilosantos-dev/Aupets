using Contracts;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Entities.DataTransferObjects;


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
    }
}