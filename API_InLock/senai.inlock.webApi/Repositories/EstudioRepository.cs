using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using System.Data.SqlClient;

namespace senai.inlock.webApi.Repositories
{
    public class EstudioRepository : IEstudioRepository
    {
        private string stringConexao = "Data Source = NOTE20-S15; Initial Catalog = inlock_games_manha; User Id = sa; pwd = Senai@134; TrustServerCertificate = true";
        public void Cadastrar(EstudioDomain novoEstudio)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querryInsert = "INSERT INTO Estudio (Nome) VALUES ('"+ novoEstudio.Nome +"')";

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
                string querryDelete = "DELETE FROM Estudio WHERE idEstudio = @IdDelete";

                using (SqlCommand cmd = new SqlCommand(querryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@IdDelete", id);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<EstudioDomain> ListarTodos()
        {
            List<EstudioDomain> listaEstudio = new List<EstudioDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querrySelectAll = "SELECT IdEstudio, Nome FROM Estudio";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(querrySelectAll, con))
                {
                    
                SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        EstudioDomain estudio = new EstudioDomain()
                        {
                            IdEstudio = Convert.ToInt32(rdr["IdEstudio"]),
                            Nome = rdr["Nome"].ToString()
                        };
                        listaEstudio.Add(estudio);
                    }
                }
                return listaEstudio;
            }
        }
    }
}
