using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using System.Data.SqlClient;
using System.Drawing;

namespace senai.inlock.webApi.Repositories
{
    /// <summary>
    /// Repositorio de Jogo, contem os metodos de jogo
    /// </summary>
    public class JogoRepository : IJogoRepository
    {
        private string stringConexao = "Data Source = NOTE20-S15; Initial Catalog = inlock_games_manha; User Id = sa; pwd = Senai@134";

        /// <summary>
        /// Busca o jogo (objeto) atraves do ID informado
        /// </summary>
        /// <param name="id">ID a ser buscado</param>
        /// <returns>Jogo (objeto) encontrado</returns>
        public JogoDomain BuscarPorId(int id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queerySearch = "SELECT IdJogo, IdEstudio, Nome, Descricao, DataLancamento, Valor FROM Jogo WHERE IdJogo = @IdBuscado";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(queerySearch, con))
                {
                    cmd.Parameters.AddWithValue("@IdBuscado", id);

                    SqlDataReader rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        JogoDomain jogo = new JogoDomain()
                        {
                            IdJogo = Convert.ToInt32(rdr["IdJogo"]),
                            IdEstudio = Convert.ToInt32(rdr["IdEstudio"]),
                            Nome = rdr["Nome"].ToString(),
                            Descricao = rdr["Descricao"].ToString(),
                            DataLancamento = Convert.ToDateTime(rdr["DataLancamento"]),
                            Valor = Convert.ToDouble(rdr["Valor"])
                        };
                        return jogo;
                    }
                    else
                    {
                        return null!;
                    }
                }
            }
        }

        /// <summary>
        /// Cadastra um novo jogo (objeto)
        /// </summary>
        /// <param name="novoJogo">novo jogo (objeto) com os dados a ser inseridos</param>
        public void Cadastrar(JogoDomain novoJogo)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querryInsert = "INSERT INTO Jogo (IdEstudio, Nome, Descricao, DataLancamento, Valor) VALUES (@IdEstudio, @Nome, @Descricao, @DataLancamento, @Valor)";

                using (SqlCommand cmd = new SqlCommand(querryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@IdEstudio", novoJogo.IdEstudio);
                    cmd.Parameters.AddWithValue("@Nome", novoJogo.Nome);
                    cmd.Parameters.AddWithValue("@Descricao", novoJogo.Descricao);
                    cmd.Parameters.AddWithValue("@DataLancamento", novoJogo.DataLancamento);
                    cmd.Parameters.AddWithValue("@Valor", novoJogo.Valor);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Deleta um jogo (objeto) existente atraves do seu ID
        /// </summary>
        /// <param name="id">ID a ser buscado</param>
        public void Deletar(int id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querryDelete = "DELETE FROM Jogo WHERE IdJogo = @IdDelete";

                using (SqlCommand cmd = new SqlCommand(querryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@IdDelete", id);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Lista/Exibe todos os jogos existentes
        /// </summary>
        /// <returns>lista de jogos</returns>
        public List<JogoDomain> ListarTodos()
        {
            List<JogoDomain> listaJogos = new List<JogoDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querrySelectAll = "SELECT IdJogo, IdEstudio, Nome, Descricao, DataLancamento, Valor FROM Jogo";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(querrySelectAll,con))
                {
                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        JogoDomain jogo = new JogoDomain()
                        {
                            IdJogo = Convert.ToInt32(rdr["IdJogo"]),
                            IdEstudio = Convert.ToInt32(rdr["IdEstudio"]),
                            Nome = rdr["Nome"].ToString(),
                            Descricao = rdr["Descricao"].ToString(),
                            DataLancamento = Convert.ToDateTime(rdr["DataLancamento"]),
                            Valor = Convert.ToDouble(rdr["Valor"])
                        };
                        listaJogos.Add(jogo);
                    }
                }
                return listaJogos;
            }
        }
    }
}
