using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Filmes.manha.Domains;
using WebAPI.Filmes.manha.Interfaces;
using WebAPI.Filmes.manha.Repositories;

namespace WebAPI.Filmes.manha.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class UsuarioController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository { get; set; }

        public UsuarioController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        //********************************************** GET **********************************************
        [HttpGet]
        public IActionResult Get(string email, string senha) 
        {
            try
            {
                UsuarioDomain usuarioBuscado = _usuarioRepository.Login(email, senha);

                if (usuarioBuscado == null)
                {
                    return NotFound("Usuario não encontrado");
                }
                return Ok(usuarioBuscado);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }
    }
}
