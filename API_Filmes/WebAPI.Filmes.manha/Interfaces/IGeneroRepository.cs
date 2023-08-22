using WebAPI.Filmes.manha.Domains;

namespace WebAPI.Filmes.manha.Interfaces
{
    /// <summary>
    /// Interface responsavel pelo repositorio GeneroRepository
    /// Definir os metodos que serao implementados pelo GeneroRepository
    /// </summary>
    public interface IGeneroRepository
    {
        //tipoRetorno NomeMetodo (TipoParametro nomeParametro)

        /// <summary>
        /// Cadastrar um novo genero
        /// </summary>
        /// <param name="novoGenero"></param>
        void Cadastrar(GeneroDomain novoGenero);

        /// <summary>
        /// Listar todos os objetos cadastrados
        /// </summary>
        /// <returns></returns>
        List<GeneroDomain> ListarTodos();

        /// <summary>
        /// Atualiza um objetoexistente passadando o seu id pelo corpo da requisicao
        /// </summary>
        /// <param name="genero">Objeto atualizado (novas informacoes)</param>
        void AtualizarIdCorpo(GeneroDomain genero);

        /// <summary>
        /// Atualizar objeto passando o seu id pela url
        /// </summary>
        /// <param name="id">Id do objeto que sera atualizado</param>
        /// <param name="genero">Objeto atualizado com as (novas informacoes)</param>
        void AtualizarIdURL(int id, GeneroDomain genero);

        /// <summary>
        /// Deletar um objeto
        /// </summary>
        /// <param name="id">Id do objeto que sera deletado</param>
        void Deletar(int id);

        /// <summary>
        /// Busca o objeto atraves do seu id
        /// </summary>
        /// <param name="id">id do objeto a ser atualizado</param>
        /// <returns>Objeto buscado</returns>
        GeneroDomain BuscarPorId(int id);
    }
}
