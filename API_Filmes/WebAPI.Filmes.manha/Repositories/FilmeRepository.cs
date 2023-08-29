using System.Data.SqlClient;
using WebAPI.Filmes.manha.Domains;
using WebAPI.Filmes.manha.Interfaces;

namespace WebAPI.Filmes.manha.Repositories
{
    public class FilmeRepository : IFilmeRepository
    {
        private string stringConexao = "Data Source = NOTE20-S15; Initial Catalog = Filmes; User Id = sa; pwd = Senai@134; TrustServerCertificate = true";

        //**************************************  Atualizar Id corpo  **************************************

        public void AtualizarIdCorpo(FilmeDomain novoFilme)
        {
            throw new NotImplementedException();
        }

        //**************************************  Atualizar Id URL  **************************************

        public void AtualizarIdRUL(int id, FilmeDomain filme)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querryUpdateUrl = "UPDATE Filme SET Titulo = @Titulo, IdGenero = @IdGenero WHERE IdFilme = @IdFilme";

                using (SqlCommand cmd = new SqlCommand(querryUpdateUrl,con))
                {
                    cmd.Parameters.AddWithValue("@Titulo",filme.Titulo);
                    cmd.Parameters.AddWithValue("@IdGenero", filme.Titulo);
                    cmd.Parameters.AddWithValue("@IdFilme", filme.IdFilme);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        //**************************************  Buscar por ID  **************************************

        /// <summary>
        /// Realiza uma pesquisa/busca com base no ID informado
        /// </summary>
        /// <param name="id">ID do objeto a ser buscado</param>
        /// <returns>retorna o objeto encontrado</returns>
        public FilmeDomain BuscarPorId(int id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querrySearch = "SELECT IdFilme, IdGenero, Titulo FROM Filme WHERE IdFilme = @IdBuscado";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querrySearch, con))
                {
                    cmd.Parameters.AddWithValue("@IdBuscado", id);

                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        FilmeDomain filme = new FilmeDomain()
                        {
                            IdFilme = Convert.ToInt32(rdr["IdFilme"]),
                            IdGenero = Convert.ToInt32(rdr["IdGenero"]),
                            Titulo = rdr["Titulo"].ToString(),
                        };

                        return filme;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }

        //**************************************  Cadastrar filme  **************************************
        /// <summary>
        /// Cadastra um novo filme (objeto) com as informações inseridas
        /// </summary>
        /// <param name="novoFilme"></param>
        public void Cadastrar(FilmeDomain novoFilme)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querryInsert = "INSERT INTO Filme(IdGenero, Titulo) VALUES (@IdGenero, @Titulo)";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(querryInsert,con))
                {
                    cmd.Parameters.AddWithValue("@IdGenero", novoFilme.IdGenero);
                    cmd.Parameters.AddWithValue("@Titulo", novoFilme.Titulo);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        //**************************************  Deletar  **************************************

        public void Deletar(int id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querryDelete = "DELETE FROM Filme WHERE IdFilme = @IdBuscado";

                using (SqlCommand cmd = new SqlCommand(querryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@IdBuscado", id);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        //**************************************  ListarTodos  **************************************
        /// <summary>
        /// Listar todos os objetos filmes
        /// </summary>
        /// <returns> Lista de objetos </returns>
        public List<FilmeDomain> ListarTodos()
        {
            List<FilmeDomain> listaFilmes = new List<FilmeDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querrySelectAll = "SELECT IdFilme, IdGenero, Titulo FROM Filme";
                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querrySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();
                    
                    while(rdr.Read())
                    { 
                        FilmeDomain filme = new FilmeDomain();

                        filme.IdFilme = Convert.ToInt32(rdr[0]);
                        filme.IdGenero = Convert.ToInt32(rdr[1]);
                        filme.Titulo = rdr[2].ToString();

                        listaFilmes.Add(filme);
                    }

                }

            }
                return listaFilmes;
        }
    }
}