using AutoMapper;
using Contracts;
using Microsoft.AspNetCore.Mvc;
using Entities.Models;
using Entities.DataTransferObjects;

namespace AupetsServer.Controllers
{
    [ApiController]
    [Route("api/avaliacao")]
    public class AvaliacaoController : ControllerBase
    {
        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;
        private IMapper _mapper;

        public AvaliacaoController(ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllAvaliacoes()
        {
            try
            {
                var avaliacao = _repository.Avaliacao.GetAllAvaliacoes();
                _logger.LogInfo($"Retornando todos as avaliacoes do banco de dados. ");

                var avalResult = _mapper.Map<IEnumerable<AvaliacaoDto>>(avaliacao);
                return Ok(avalResult);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Ocorreu um erro no método GetAllAvaliacoes: {ex.Message}");
                return StatusCode(500, "Erro interno do Servidor");
            }
        }

        [HttpGet("{id}", Name = "AvaliacaoById")]
        public IActionResult GetAvaliacaoById(int avaliacaoId)
        {
            try
            {
                var avaliacao = _repository.Avaliacao.GetAvaliacaoById(avaliacaoId);

                if (avaliacao is null)
                {
                    _logger.LogError($"Avaliacao com Id: {avaliacaoId}, não encontrado.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Retornando a avaliacao com Id: {avaliacaoId}.");

                    var avalResult = _mapper.Map<AtuacaoDto>(avaliacao);
                    return Ok(avalResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Ocorreu um erro no metodo GetAvaliacaoById: {ex.Message}");
                return StatusCode(500, "Erro Interno do Servidor");
            }
        }

        [HttpPost]
        public IActionResult CreateAvaliacao([FromBody] AvaliacaoForCreationDto avaliacao)
        {
            try
            {
                if (avaliacao is null)
                {
                    _logger.LogError("Objeto Avaliacao enviado está nulo.");
                    return BadRequest("Objeto Avaliacao é nulo");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Objeto Avaliacao enviado é inválido.");
                    return BadRequest("Objeto de modelo inválido");
                }

                var avalEntity = _mapper.Map<Avaliacoes>(avaliacao);

                _repository.Avaliacao.CreateAvaliacao(avalEntity);
                _repository.Save();

                var createdAvaliacao = _mapper.Map<AtuacaoDto>(avalEntity);

                return CreatedAtRoute("AvaliacaoById", new { id = createdAvaliacao.Id }, createdAvaliacao);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Ocorreu um erro no método CreateAvaliacao: {ex.Message}");
                return StatusCode(500, "Erro Interno do Servidor");
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateAvaliacao(int id, [FromBody] AvaliacaoForUpdateDto avaliacao)
        {
            try
            {
                if (avaliacao is null)
                {
                    _logger.LogError("Objeto Avaliacao enviado está nulo.");
                    return BadRequest("Objeto Avaliacao é nulo");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Objeto Avaliacao enviado é Invalido.");
                    return BadRequest("Objeto de modelo inválido");
                }

                var avalEntity = _repository.Avaliacao.GetAvaliacaoById(id);
                if (avalEntity is null)
                {
                    _logger.LogError($"Avaliacao com Id: {id}, não encontrado.");
                    return NotFound();
                }

                _mapper.Map(avaliacao, avalEntity);

                _repository.Avaliacao.UpdateAvaliacao(avalEntity);
                _repository.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Ocorreu um erro no método UpdateAvaliacao: {ex.Message}");
                return StatusCode(500, "Erro Interno do Servidor");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAvaliacao(int id)
        {
            try
            {
                var avaliacao = _repository.Avaliacao.GetAvaliacaoById(id);
                if (avaliacao == null)
                {
                    _logger.LogError($"Avaliacao com Id: {id}, não encontrado.");
                    return NotFound();
                }
               
                _repository.Avaliacao.DeleteAvaliacao(avaliacao);
                _repository.Save();
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Ocorreu um erro no método DeleteAvaliacao: {ex.Message}");
                return StatusCode(500, "Erro Interno do Servidor");
            }
        }

    }
}