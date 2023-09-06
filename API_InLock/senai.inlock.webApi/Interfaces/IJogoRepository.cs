using senai.inlock.webApi.Domains;

namespace senai.inlock.webApi.Interfaces
{
    public interface IJogoRepository
    {
        /// <summary>
        /// Lista e exibe todos os jogos existentes no banco de dados
        /// </summary>
        /// <returns></returns>
        List<JogoDomain> ListarTodos();

        /// <summary>
        /// Busca o jogo desejado por id
        /// </summary>
        /// <param name="id">id do jogo a ser buscado</param>
        /// <returns>jogo encontrado</returns>
        JogoDomain BuscarPorId(int id);

        /// <summary>
        /// Cadastra um novo jogo (objeto)
        /// </summary>
        /// <param name="novoJogo">objeto do jogo com todas as informacoes</param>
        void Cadastrar(JogoDomain novoJogo);

        /// <summary>
        /// Deleta um jogo atraves do seu id
        /// </summary>
        /// <param name="id">id do jogo a ser deletado</param>
        void Deletar(int id);
    }
}
