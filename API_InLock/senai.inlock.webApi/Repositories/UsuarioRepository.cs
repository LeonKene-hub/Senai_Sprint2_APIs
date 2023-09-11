using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using System.Data.SqlClient;

namespace senai.inlock.webApi.Repositories
{
    /// <summary>
    /// Repositorio de Usuario, contem metodos de manipulação de dados
    /// </summary>
    public class UsuarioRepository : IUsuarioRepository
    {
        private string stringConexao = "Data Source = NOTE20-S15; Initial Catalog = inlock_games_manha; User Id = sa; pwd = Senai@134";

        /// <summary>
        /// Cadastra um novo usuario (objeto)
        /// </summary>
        /// <param name="novoUsuario">Novo usuario com dados preenchidos</param>
        public void Cadastrar(UsuarioDomain novoUsuario)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querryInsert = "INSERT INTO Usuario(IdTipoUsuario, Email, Senha) VALUES(@IdTipoUsuario, @Email, @Senha)";

                using (SqlCommand cmd = new SqlCommand(querryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@IdTipoUsuario", novoUsuario.IdTipoUsuario);
                    cmd.Parameters.AddWithValue("@Email", novoUsuario.Email);
                    cmd.Parameters.AddWithValue("@Senha", novoUsuario.Senha);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Deleta um usuario existente do banco de dados atraves do seu ID
        /// </summary>
        /// <param name="id">ID a ser buscado</param>
        public void Deletar(int id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querryDelete = "DELETE FROM Usuario WHERE IdUsuario = @IdDeletado";

                using (SqlCommand cmd = new SqlCommand(querryDelete, con))
                {
                    con.Open();

                    cmd.Parameters.AddWithValue("@IdDeletado", id);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Lista/Exibe todos os usuarios existentes
        /// </summary>
        /// <returns>lista de usuarios</returns>
        public List<UsuarioDomain> ListarTodos()
        {
            List<UsuarioDomain> usuarios = new List<UsuarioDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querryGetAll = "SELECT IdUsuario, IdTipoUsuario, Email, Senha FROM Usuario";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(querryGetAll, con))
                {
                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        UsuarioDomain usuario = new UsuarioDomain()
                        {
                            IdUsuario = Convert.ToInt32(rdr["IdUsuario"]),
                            IdTipoUsuario = Convert.ToInt32(rdr["IdTipoUsuario"]),
                            Email = rdr["Email"].ToString(),
                            Senha = rdr["Senha"].ToString()
                        };
                        usuarios.Add(usuario);
                    }
                    return usuarios;
                }
            }
        }

        /// <summary>
        /// Login, realiza autenticação de usuario e suas permissões
        /// </summary>
        /// <param name="email">endereço email do usuario</param>
        /// <param name="senha">senha definida pelo usuario</param>
        /// <returns>objeto com informações do usuario</returns>
        public UsuarioDomain Login(string email, string senha)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querryLogin = "SELECT Email,IdTipoUsuario FROM Usuario WHERE Email = @emailBuscado AND Senha = @senhaBuscado";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querryLogin, con))
                {
                    cmd.Parameters.AddWithValue("@emailBuscado", email);
                    cmd.Parameters.AddWithValue("@senhaBuscado", senha);

                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        UsuarioDomain usuarioEncontrado = new UsuarioDomain()
                        {
                            Email = rdr["Email"].ToString()!,
                            IdTipoUsuario = Convert.ToInt32(rdr["IdTipoUsuario"])
                        };
                        return usuarioEncontrado;
                    }
                    else
                    {
                        return null!;
                    }
                }
            }
        }
    }
}
