using System.Data.SqlClient;
using WebAPI.Filmes.manha.Interfaces;

namespace WebAPI.Filmes.manha.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private string stringConexao = "Data Source = NOTE20-S15; Initial Catalog = Filmes; User Id = sa; pwd = Senai@134; TrustServerCertificate = true";
        public void Login(string email, string senha)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querryLogin = "SELECT * FROM Usuario WHERE Email = @emailBuscado AND Senha = @senhaBuscado";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(querryLogin, con))
                {

                    cmd.Parameters.AddWithValue("@emailBuscado", email);
                    cmd.Parameters.AddWithValue("@senhaBuscado", senha);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
