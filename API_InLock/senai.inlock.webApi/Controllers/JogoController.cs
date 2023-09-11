using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using senai.inlock.webApi.Repositories;
using System.Data;

namespace senai.inlock.webApi.Controllers
{
    /// <summary>
    /// Controlador de Jogo, suas https e exucução de metodos
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class JogoController : ControllerBase
    {
        private IJogoRepository _jogoRepository { get; set; }

        /// <summary>
        /// Construtor que define ponte para exucução dos metodos
        /// </summary>
        public JogoController()
        {
            _jogoRepository = new JogoRepository();
        }

        /// <summary>
        /// Lista todos os jogos
        /// </summary>
        /// <returns>lista de jogos</returns>
        [HttpGet]
        [Authorize(Roles = "1,2")]
        public IActionResult ListarTodos()
        {
            try
            {
                List<Domains.JogoDomain> listaJogos = _jogoRepository.ListarTodos();
                return Ok(listaJogos);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        /// <summary>
        /// Buscar jogo pelo ID
        /// </summary>
        /// <param name="id">ID a ser buscado</param>
        /// <returns>jogo encontrado</returns>
        [HttpGet("{id}")]
        [Authorize(Roles = "1,2")]
        public IActionResult BuscarId(int id)
        {
            try
            {
                JogoDomain jogo = _jogoRepository.BuscarPorId(id);
                return Ok(jogo);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        /// <summary>
        /// Cadastra um novo jogo
        /// </summary>
        /// <param name="novoJogo">informações do novo jogo</param>
        /// <returns>status code informando o resultado</returns>
        [HttpPost]
        [Authorize(Roles = "2")]
        public IActionResult Cadastrar(JogoDomain novoJogo)
        {
            try
            {
                _jogoRepository.Cadastrar(novoJogo);
                return StatusCode(201);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Deleta um jogo atraves do seu ID
        /// </summary>
        /// <param name="id">ID a ser buscado</param>
        /// <returns>status code informando o resultado</returns>
        [HttpDelete]
        [Authorize(Roles = "2")]
        public IActionResult Deletar(int id)
        {
            try
            {
                _jogoRepository.Deletar(id);
                return StatusCode(204);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }
    }
}
