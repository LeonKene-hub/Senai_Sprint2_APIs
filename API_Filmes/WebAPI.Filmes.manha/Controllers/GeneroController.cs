using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Filmes.manha.Domains;
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

        //**************************************** GET ****************************************

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

        //**************************************** POST ****************************************

        /// <summary>
        /// Endpoint que aciona o metodo de cadastro de genero
        /// </summary>
        /// <param name="novoGenero">Objeto recebido na requisicao</param>
        /// <returns>status code 201(created)</returns>
        [HttpPost]
        public IActionResult Post(GeneroDomain novoGenero)
        {
            try
            {
                //Fazeno a chamada para o metodo cadastrar passando o objeto como parametro
                _generoRepository.Cadastrar(novoGenero);
                //retorna o status code 201 - created
                return StatusCode(201);

            }
            catch (Exception erro)
            {
                //retorna status code 400 (BadRequest) e a mensagem de erro
                return BadRequest(erro.Message);
            }
        }

        //**************************************** DELETE ****************************************

        [HttpDelete("{id}")]

        public IActionResult Delete(int id)
        {
            try
            {
                _generoRepository.Deletar(id);

                return StatusCode(204);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }
    }
}
