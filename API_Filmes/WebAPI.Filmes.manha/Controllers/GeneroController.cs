using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Filmes.manha.Interfaces;
using WebAPI.Filmes.manha.Repositories;

namespace WebAPI.Filmes.manha.Controllers
{
    //define que a rota de uma requisicao sera no seguinte formato
    //dominio/api/nomeController
    //ex: https//localhost:5000/api/Genero
    [Route("api/[controller]")]

    //define que e um controlador API
    [ApiController]

    //define que o tipo de resposta da API sera no formato JSON
    [Produces("application/json")]

    //Metodo controlador que herda da controler base
    //onde sera criado os endpoints (rotas)
    public class GeneroController : ControllerBase
    {
        /// <summary>
        /// Objeto _generoRepository que ira receber todos os metodos definidos na interface IGeneroRepository
        /// </summary>
        private IGeneroRepository _generoRepository { get; set; }

        /// <summary>
        /// Instancia o objeto _generoRepository para que haja referencia aos metodos no repositorio
        /// </summary>
        public GeneroController()
        {
            _generoRepository = new GeneroRepository();
        }

        /// <summary>
        /// Endpoint que aciona o metodo Listar todos no repositorio e retorna a resposta para o usuario (front-end)
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get() 
        {
            try
            {
                //Cria uma lista que recebe os dados d requisicao
                List<Domains.GeneroDomain> listaGeneros = _generoRepository.ListarTodos();

                //retorna a lista em formato JSON com o status OK
                return Ok(listaGeneros);
            }
            catch (Exception erro)
            {
                //retorna um status code BasRequest(400) e a mensagem do erro
                return BadRequest(erro);
            }
        }
    }
}
