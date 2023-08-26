using WebAPI.Filmes.manha.Domains;

namespace WebAPI.Filmes.manha.Interfaces
{
    public interface IFilmeRepository
    {
        /// <summary>
        /// Cadastrar um filme (objeto)
        /// </summary>
        /// <param name="novoFilme"> nome do novo filme (objeto) </param>
        void Cadastrar(FilmeDomain novoFilme);

        /// <summary>
        /// Listar todos os filmes
        /// </summary>
        /// <returns> Lista com todos os filmes (objetos) </returns>
        List<FilmeDomain> ListarTodos();

        /// <summary>
        /// Atualizar objeto existente passando pelo seu ID pelo corpo de requisição
        /// </summary>
        /// <param name="novoFilme"> Objeto atualizado (novas informações) </param>
        void AtualizarIdCorpo(FilmeDomain novoFilme);

        /// <summary>
        /// Atualizar um objeto existente passando o seu id pela URL
        /// </summary>
        /// <param name="id"> ID do objeto que sera atualizado </param>
        /// <param name="filme"> objeto atualizado (novas informações) </param>
        void AtualizarIdRUL(int id, FilmeDomain filme);


        /// <summary>
        /// Deletar um objeto pelo ID
        /// </summary>
        /// <param name="id"> ID do objeto que sera deletado </param>
        void Deletar(int id);

        /// <summary>
        /// Buscar pelo id do objeto
        /// </summary>
        /// <param name="id"> Objeto buscado </param>
        /// <returns></returns>
        FilmeDomain BuscarPorId(int id);
    }
}
