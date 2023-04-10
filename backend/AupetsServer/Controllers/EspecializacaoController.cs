using Contracts;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Entities.DataTransferObjects.EspecializacaoDtos;
using Entities.Models;

namespace AupetsServer.Controllers
{
    [ApiController]
    [Route("api/especializacao")]
    public class EspecializacaoController : ControllerBase
    {

        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;
        private IMapper _mapper;

        public EspecializacaoController(ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllEspecializacao()
        {
            try
            {
                var especializacao = _repository.Especializacao.GetAllEspecializacao();
                _logger.LogInfo($"Retornando todos as especializacoes do banco de dados. ");

                var especialiResult = _mapper.Map<IEnumerable<EspecializacaoDto>>(especializacao);
                return Ok(especialiResult);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Ocorreu um erro no método GetAllEspecializacao: {ex.Message}");
                return StatusCode(500, "Erro interno do Servidor");
            }
        }

        [HttpGet("{id}", Name = "EspecializacaoById")]
        public IActionResult GetEspecializacaoById(Int16 especializacaoId)
        {
            try
            {
                var especializacao = _repository.Especializacao.GetEspecializacaoById(especializacaoId);

                if (especializacao is null)
                {
                    _logger.LogError($"Especializacao com Id: {especializacaoId}, não encontrado.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Retornando a especializacao com Id: {especializacaoId}.");

                    var especialiResult = _mapper.Map<EspecializacaoDto>(especializacao);
                    return Ok(especialiResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Ocorreu um erro no metodo GetEspecializacaoById: {ex.Message}");
                return StatusCode(500, "Erro Interno do Servidor");
            }
        }

        [HttpPost]
        public IActionResult CreateEspecializacao([FromBody] EspecializacaoForCreationDto especializacao)
        {
            try
            {
                if (especializacao is null)
                {
                    _logger.LogError("Objeto Especializacao enviado está nulo.");
                    return BadRequest("Objeto Especializacao é nulo");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Objeto Especializacao enviado é inválido.");
                    return BadRequest("Objeto de modelo inválido");
                }

                var especialiEntity = _mapper.Map<Especializacao>(especializacao);

                _repository.Especializacao.CreateEspecializacao(especialiEntity);
                _repository.Save();

                var createdEspecializacao = _mapper.Map<EspecializacaoDto>(especialiEntity);

                return CreatedAtRoute("EspecializacaoById", new { id = createdEspecializacao.Id }, createdEspecializacao);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Ocorreu um erro no mpetodo CreateEspecializacao: {ex.Message}");
                return StatusCode(500, "Erro Interno do Servidor");
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateEspecializacao(Int16 id, [FromBody] EspecializacaoForUpdateDto especializacao)
        {
            try
            {
                if (especializacao is null)
                {
                    _logger.LogError("Objeto Especializacao enviado está nulo.");
                    return BadRequest("Objeto Especializacao é nulo");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Objeto Especializacao enviado é Invalido.");
                    return BadRequest("Objeto de modelo inválido");
                }

                var especialiEntity = _repository.Especializacao.GetEspecializacaoById(id);
                if (especialiEntity is null)
                {
                    _logger.LogError($"Especializacao com Id: {id}, não encontrado.");
                    return NotFound();
                }

                _mapper.Map(especializacao, especialiEntity);

                _repository.Especializacao.UpdateEspecializacao(especialiEntity);
                _repository.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Ocorreu um erro no método UpdateEspecializacao: {ex.Message}");
                return StatusCode(500, "Erro Interno do Servidor");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEspecializacao(Int16 id)
        {
            try
            {
                var especializacao = _repository.Especializacao.GetEspecializacaoById(id);
                if (especializacao == null)
                {
                    _logger.LogError($"Especializacao com Id: {id}, não encontrado.");
                    return NotFound();
                }
               
                _repository.Especializacao.DeleteEspecializacao(especializacao);
                _repository.Save();
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Ocorreu um erro no método DeleteEspecializacao: {ex.Message}");
                return StatusCode(500, "Erro Interno do Servidor");
            }
        }
        
    }
}