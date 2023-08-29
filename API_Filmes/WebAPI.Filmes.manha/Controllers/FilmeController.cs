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
    public class FilmeController : Controller
    {
        private IFilmeRepository _filmeRepository { get; set; }

        public FilmeController()
        {
            _filmeRepository = new FilmeRepository();
        }

        //******************************************** GET ********************************************
        /// <summary>
        /// Endpoint que aciona o metodo de listar todos os filmes
        /// </summary>
        /// <returns>Lista todos os filmes</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List<FilmeDomain> listaFilmes = _filmeRepository.ListarTodos();
                return Ok(listaFilmes);
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        }

        //******************************************** GET (id) ********************************************
        /// <summary>
        /// Endpoint que aciona o metodo de buscar de filme pelo seu ID
        /// </summary>
        /// <param name="id">Id do filme a ser buscado</param>
        /// <returns>O filme encontrado</returns>
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                FilmeDomain filmeBuscado = _filmeRepository.BuscarPorId(id);

                if (filmeBuscado == null)
                {
                    return NotFound("Nenhum filme foi encontrado");
                }

                return Ok(filmeBuscado);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        //******************************************** POST ********************************************
        /// <summary>
        /// Endpoint que aciona o metodo de cadastro de filmes
        /// </summary>
        /// <param name="novoFilme"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post(FilmeDomain novoFilme)
        {
            try
            {
                _filmeRepository.Cadastrar(novoFilme);
                return StatusCode(201);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }

        }

        //******************************************** DELETE ********************************************

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _filmeRepository.Deletar(id);
                return StatusCode(204);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        //******************************************** PUT ********************************************

        [HttpPut("{id}")]
        public IActionResult Put(int id, FilmeDomain filme)
        {
            try
            {
                _filmeRepository.AtualizarIdRUL(id, filme);
                return StatusCode(204);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }
    }
}
