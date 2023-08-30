using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Filmes.manha.Interfaces;
using WebAPI.Filmes.manha.Repositories;

namespace WebAPI.Filmes.manha.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
                _usuarioRepository.Login(email, senha);
                return StatusCode(200);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }
    }
}
