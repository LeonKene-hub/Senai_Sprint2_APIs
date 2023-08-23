using System.Data.SqlClient;
using WebAPI.Filmes.manha.Domains;
using WebAPI.Filmes.manha.Interfaces;

namespace WebAPI.Filmes.manha.Repositories
{
    public class FilmeRepository : IFilmeRepository
    {
        private string stringConexao = "Data Source = NOTE20-S15; Initial Catalog = Filmes; User Id = sa; pwd = Senai@134; TrustServerCertificate = true";
        public void AtualizarIdCorpo(FilmeDomain novoFilme)
        {
            throw new NotImplementedException();
        }

        public void AtualizarIdRUL(int id, FilmeDomain filme)
        {
            throw new NotImplementedException();
        }

        public FilmeDomain BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(FilmeDomain novoFilme)
        {
            throw new NotImplementedException();
        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }

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
