using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using System.Data.SqlClient;

namespace senai.inlock.webApi.Repositories
{
    /// <summary>
    /// Repositorio de TipoUsuario, contém os metodos de TipoUsuario
    /// </summary>
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
        private string stringConexao = "Data Source = NOTE20-S15; Initial Catalog = inlock_games_manha; User Id = sa; pwd = Senai@134";

        /// <summary>
        /// Cadastra um novo tipo de usuario (objeto)
        /// </summary>
        /// <param name="novoTipo">novo tipo de usuario (objeto) com informações preenchidas</param>
        public void Cadastrar(TiposUsuarioDomain novoTipo)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querryInsert = "INSERT INTO TiposUsuario (TiTulo) VALUES ('"+novoTipo.Titulo+"')";

                using (SqlCommand cmd = new SqlCommand(querryInsert, con))
                {
                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Deleta um tipo de usuario existente atraves do seu ID
        /// </summary>
        /// <param name="id">ID a ser buscado</param>
        public void Deletar(int id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querryDelete = "DELETE FROM TiposUsuario WHERE IdTipoUsuario = @IdBuscado";

                using (SqlCommand cmd = new SqlCommand(querryDelete,con))
                {
                    cmd.Parameters.AddWithValue("@IdBuscado", id);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Lista/Exibe todos os tipos de usuario existentes
        /// </summary>
        /// <returns>lista de tipos</returns>
        public List<TiposUsuarioDomain> ListarTodos()
        {
            List<TiposUsuarioDomain> tipoUsuarios = new List<TiposUsuarioDomain> ();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querryGetAll = "SELECT IdTipoUsuario, Titulo FROM TiposUsuario";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(querryGetAll, con))
                {
                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        TiposUsuarioDomain tipo = new TiposUsuarioDomain()
                        {
                            IdTipoUsuario = Convert.ToInt32(rdr["IdTipoUsuario"]),
                            Titulo = rdr["Titulo"].ToString()
                        };
                        tipoUsuarios.Add(tipo);
                    }
                    return tipoUsuarios;
                }
            }
        }
    }
}
