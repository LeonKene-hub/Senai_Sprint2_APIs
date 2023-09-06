using senai.inlock.webApi.Domains;

namespace senai.inlock.webApi.Interfaces
{
    public interface IUsuarioRepository
    {
        /// <summary>
        /// Lista e exibe os usuarios existente
        /// </summary>
        /// <returns>lista de usuarios</returns>
        List<UsuarioDomain> ListarTodos();

        /// <summary>
        /// Cadastra um novo usuario (objeto)
        /// </summary>
        /// <param name="novoUsuario">objeto com as informacoes do novo usuario</param>
        void Cadastrar(UsuarioDomain novoUsuario);

        /// <summary>
        /// Deleta um usuario atraves do seu id
        /// </summary>
        /// <param name="id">id do usuario a ser deletado</param>
        void Deletar(int id);

        /// <summary>
        /// Loga em um usuario ja existente
        /// </summary>
        /// <param name="email">email do usuario registrado</param>
        /// <param name="senha">senha do usuario registrado</param>
        /// <returns>login e permissao de acesso</returns>
        public UsuarioDomain Login (string email, string senha);
    }
}
