using senai.inlock.webApi.Domains;

namespace senai.inlock.webApi.Interfaces
{
    public interface ITipoUsuarioRepository
    {
        /// <summary>
        /// Cadastra um novo tipo de usuario
        /// </summary>
        /// <param name="novoTipo">objeto do tipo de usuario com todas as informacoes</param>
        void Cadastrar(TiposUsuarioDomain novoTipo);

        /// <summary>
        /// Deleta o tipo atraves do seu id
        /// </summary>
        /// <param name="id">id do tipo a ser deletado</param>
        void Deletar(int id);

        /// <summary>
        /// Lista e exibe todos os tipos de usuario existente
        /// </summary>
        /// <returns>lista de tipo</returns>
        List<TiposUsuarioDomain> ListarTodos();
    }
}
