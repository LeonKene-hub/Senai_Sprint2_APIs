using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using senai.inlock.webApi.Repositories;

namespace senai.inlock.webApi.Controllers
{
    /// <summary>
    /// Controlador de TipoUsuario, suas https e exucução de metodos
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [Authorize]
    public class TipoUsuarioController : ControllerBase
    {
        private ITipoUsuarioRepository _tipoUsuarioRepository {  get; set; }

        /// <summary>
        /// Construtor que define ponte para exucução dos metodos
        /// </summary>
        public TipoUsuarioController()
        {
                _tipoUsuarioRepository = new TipoUsuarioRepository();
        }

        /// <summary>
        /// Lista todos os tipos de usuario
        /// </summary>
        /// <returns>lista de tipos de usuario</returns>
        [HttpGet]
        [Authorize(Roles = "1,2")]
        public IActionResult ListarTodos()
        {
            try
            {
                List<Domains.TiposUsuarioDomain> listaTipos = _tipoUsuarioRepository.ListarTodos();
                return Ok(listaTipos);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        /// <summary>
        /// Cadastra um novo Tipo de usuario
        /// </summary>
        /// <param name="novoTipo">informações do novo tipo</param>
        /// <returns>status code informando o resultado</returns>
        [HttpPost]
        [Authorize(Roles = "2")]
        public IActionResult Cadastrar(TiposUsuarioDomain novoTipo)
        {
            try
            {
                _tipoUsuarioRepository.Cadastrar(novoTipo);
                return StatusCode(201);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        /// <summary>
        /// Deleta um tipo atraves do seu ID
        /// </summary>
        /// <param name="id">ID a ser buscado</param>
        /// <returns>status code informando o resultado</returns>
        [HttpDelete]
        [Authorize(Roles = "2")]
        public IActionResult Deletar(int id)
        {
            try
            {
                _tipoUsuarioRepository.Deletar(id);
                return StatusCode(204);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }
    }
}
