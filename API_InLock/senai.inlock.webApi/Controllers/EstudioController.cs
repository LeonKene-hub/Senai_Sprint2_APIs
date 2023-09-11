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
    /// Controlador de Estudio, suas https e exucução de metodos
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class EstudioController : ControllerBase
    {
        private IEstudioRepository _estudioRepository { get; set; }

        /// <summary>
        /// Construtor que define ponte para exucução dos metodos
        /// </summary>
        public EstudioController()
        {
            _estudioRepository= new EstudioRepository();
        }

        /// <summary>
        /// Lista todos os estudios
        /// </summary>
        /// <returns>lista de estudios</returns>
        [HttpGet]
        [Authorize(Roles = "1,2")]
        public IActionResult ListarTodos()
        {
            try
            {
                List<Domains.EstudioDomain> listaEstudios = _estudioRepository.ListarTodos();

                return Ok(listaEstudios);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        /// <summary>
        /// Cadastra um novo estudio
        /// </summary>
        /// <param name="novoEstudio">informações do novo estudio</param>
        /// <returns>status code informando o resultado</returns>
        [HttpPost]
        [Authorize(Roles = "2")]
        public IActionResult Cadastrar(EstudioDomain novoEstudio)
        {
            try
            {
                _estudioRepository.Cadastrar(novoEstudio);
                return StatusCode(201);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        /// <summary>
        /// Deleta um estudio atraves do seu ID
        /// </summary>
        /// <param name="id">ID a ser buscado</param>
        /// <returns>status code informando o resultado</returns>
        [HttpDelete]
        [Authorize(Roles = "2")]
        public IActionResult Delete(int id)
        {
            try
            {
                _estudioRepository.Deletar(id);
                return StatusCode(204);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }
    }
}
