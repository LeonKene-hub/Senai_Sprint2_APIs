using System.Data.SqlClient;
using WebAPI.Filmes.manha.Domains;
using WebAPI.Filmes.manha.Interfaces;

namespace WebAPI.Filmes.manha.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private string stringConexao = "Data Source = NOTE20-S15; Initial Catalog = Filmes; User Id = sa; pwd = Senai@134; TrustServerCertificate = true";
        public UsuarioDomain Login(string email, string senha)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querryLogin = "SELECT Email,Permissao FROM Usuario WHERE Email = @emailBuscado AND Senha = @senhaBuscado";

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
                            Permissao = Convert.ToBoolean(rdr["Permissao"])
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
