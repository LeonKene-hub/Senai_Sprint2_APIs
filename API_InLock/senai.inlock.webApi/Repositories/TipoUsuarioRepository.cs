using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using System.Data.SqlClient;

namespace senai.inlock.webApi.Repositories
{
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
        private string stringConexao = "Data Source = NOTE20-S15; Initial Catalog = inlock_games_manha; User Id = sa; pwd = Senai@134; TrustServerCertificate = true";

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
