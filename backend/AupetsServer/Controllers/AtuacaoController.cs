using AutoMapper;
using Contracts;
using Microsoft.AspNetCore.Mvc;
using Entities.Models;
using Entities.DataTransferObjects;

namespace AupetsServer.Controllers
{
    [ApiController]
    [Route("api/atuacao")]
    public class AtuacaoController : ControllerBase
    {
        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;
        private IMapper _mapper;

        public AtuacaoController(ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllAtuacao()
        {
            try
            {
                var atuacao = _repository.Atuacao.GetAllAtuacao();
                _logger.LogInfo($"Retornando todos as atuacoes do banco de dados. ");

                var atuaResult = _mapper.Map<IEnumerable<AtuacaoDto>>(atuacao);
                return Ok(atuaResult);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Ocorreu um erro no método GetAllAtuacao: {ex.Message}");
                return StatusCode(500, "Erro interno do Servidor");
            }
        }

        [HttpGet("{id}", Name = "AtuacaoById")]
        public IActionResult GetAtuacaoById(Int16 atuacaoId)
        {
            try
            {
                var atuacao = _repository.Atuacao.GetAtuacaoById(atuacaoId);

                if (atuacao is null)
                {
                    _logger.LogError($"Atuacao com Id: {atuacaoId}, não encontrado.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Retornando a atuacao com Id: {atuacaoId}.");

                    var atuaResult = _mapper.Map<AtuacaoDto>(atuacao);
                    return Ok(atuaResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Ocorreu um erro no metodo GetAtuacaoById: {ex.Message}");
                return StatusCode(500, "Erro Interno do Servidor");
            }
        }

        [HttpPost]
        public IActionResult CreateAtuacao([FromBody] AtuacaoForCreationDto atuacao)
        {
            try
            {
                if (atuacao is null)
                {
                    _logger.LogError("Objeto Atuacao enviado está nulo.");
                    return BadRequest("Objeto Atuacao é nulo");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Objeto Atuacao enviado é inválido.");
                    return BadRequest("Objeto de modelo inválido");
                }

                var atuaEntity = _mapper.Map<Atuacao>(atuacao);

                _repository.Atuacao.CreateAtuacao(atuaEntity);
                _repository.Save();

                var createdAtuacao = _mapper.Map<AtuacaoDto>(atuaEntity);

                return CreatedAtRoute("AtuacaoById", new { id = createdAtuacao.Id }, createdAtuacao);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Ocorreu um erro no método CreateAtuacao: {ex.Message}");
                return StatusCode(500, "Erro Interno do Servidor");
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateAtuacao(Int16 id, [FromBody] AtuacaoForUpdateDto atuacao)
        {
            try
            {
                if (atuacao is null)
                {
                    _logger.LogError("Objeto Atuacao enviado está nulo.");
                    return BadRequest("Objeto Atuacao é nulo");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Objeto Atuacao enviado é Invalido.");
                    return BadRequest("Objeto de modelo inválido");
                }

                var atuaEntity = _repository.Atuacao.GetAtuacaoById(id);
                if (atuaEntity is null)
                {
                    _logger.LogError($"Atuacao com Id: {id}, não encontrado.");
                    return NotFound();
                }

                _mapper.Map(atuacao, atuaEntity);

                _repository.Atuacao.UpdateAtuacao(atuaEntity);
                _repository.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Ocorreu um erro no método UpdateAtuacao: {ex.Message}");
                return StatusCode(500, "Erro Interno do Servidor");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAtuacao(Int16 id)
        {
            try
            {
                var atuacao = _repository.Atuacao.GetAtuacaoById(id);
                if (atuacao == null)
                {
                    _logger.LogError($"Atuacao com Id: {id}, não encontrado.");
                    return NotFound();
                }
               
                _repository.Atuacao.DeleteAtuacao(atuacao);
                _repository.Save();
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Ocorreu um erro no método DeleteAtuacao: {ex.Message}");
                return StatusCode(500, "Erro Interno do Servidor");
            }
        }

    }
}