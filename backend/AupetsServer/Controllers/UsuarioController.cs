using Contracts;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.AspNetCore.Identity;

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
            // Esse codigo está forçando  o seed de um administrador
            var userId = Guid.NewGuid();
            var hash = new PasswordHasher<Usuario>();
            var usuario = new Usuario()
            {
                Id = userId,
                Nome = "Lucas Santos de Oliveira",
                Senha = hash.HashPassword(null, "123456"),
                SenhaHash = hash.GetHashCode().ToString(),
                Email = "lucas.santos@admin.admin",
                EAdmin = true
            };
            _repository.Usuario.CreateUsuario(usuario);
            _repository.Save();
            
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

        [HttpGet("{id}", Name = "UsuarioById") ]
        public IActionResult GetUsuarioById(Guid id)
        {
            try
            {
                var usuario = _repository.Usuario.GetUsuarioById(id);
                if (usuario is null)
                {
                    _logger.LogError($"Usuario com Id: {id}, não encontrado");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Retornando o usuario com Id: {id}");

                    var usuarioResult = _mapper.Map<UsuarioDto>(usuario);
                    return Ok(usuarioResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Ocorreu um erro no método GetUsuarioId: {ex.Message}");
                return StatusCode(500, "Erro Interno do Servidor");
            }
        }

        [HttpPost]
        public IActionResult CreateUsuario([FromBody] UsuarioForCreationDto usuario)
        {
            try
            {
                if (usuario is null)
                {
                    _logger.LogError("Objeto Usuario enviado está nulo.");
                    return BadRequest("Objeto Usuario é nulo");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Objeto Usuario enviado é inválido.");
                    return BadRequest("Objeto de modelo inválido");
                }

                var usuarioEntity = _mapper.Map<Usuario>(usuario);

                _repository.Usuario.CreateUsuario(usuarioEntity);
                _repository.Save();

                var createdUsuario = _mapper.Map<UsuarioDto>(usuarioEntity);

                return CreatedAtRoute("UsuarioById", new { id = createdUsuario.Id }, createdUsuario);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Ocorreu um erro no mpetodo CreateUsuario: {ex.Message}");
                return StatusCode(500, "Erro Interno do Servidor");
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUsuario(Guid id, [FromBody] UsuarioForUpdateDto usuario)
        {
            try
            {
                if (usuario is null)
                {
                    _logger.LogError("Objeto Usuario enviado está nulo.");
                    return BadRequest("Objeto Usuario é nulo");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Objeto Usuario enviado é Invalido.");
                    return BadRequest("Objeto de modelo inválido");
                }

                var usuarioEntity = _repository.Usuario.GetUsuarioById(id);
                if (usuarioEntity is null)
                {
                    _logger.LogError($"Owner com Id: {id}, não encontrado.");
                    return NotFound();
                }

                _mapper.Map(usuario, usuarioEntity);

                _repository.Usuario.UpdateUsuario(usuarioEntity);
                _repository.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Ocorreu um erro no método UpdateUsuario: {ex.Message}");
                return StatusCode(500, "Erro Interno do Servidor");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUsuario(Guid id)
        {
            try
            {
                var usuario = _repository.Usuario.GetUsuarioById(id);
                if (usuario == null)
                {
                    _logger.LogError($"Usuario com Id: {id}, não encontrado.");
                    return NotFound();
                }
               
                _repository.Usuario.DeleteUsuario(usuario);
                _repository.Save();
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Ocorreu um erro no método DeleteUsuario: {ex.Message}");
                return StatusCode(500, "Erro Interno do Servidor");
            }
        }
    }
}

