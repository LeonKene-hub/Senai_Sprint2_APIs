using System.Data.SqlClient;
using WebAPI.Filmes.manha.Domains;
using WebAPI.Filmes.manha.Interfaces;

namespace WebAPI.Filmes.manha.Repositories
{
    public class GeneroRepository : IGeneroRepository
    {
        private string stringConexao = "Data Source = NOTE20-S15; Initial Catalog = Filmes; User Id = sa; pwd = Senai@134; TrustServerCertificate = true";
        public void AtualizarIdCorpo(GeneroDomain genero)
        {
            throw new NotImplementedException();
        }

        public void AtualizarIdURL(int id, GeneroDomain genero)
        {
            throw new NotImplementedException();
        }

        public GeneroDomain BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(GeneroDomain novoGenero)
        {
            throw new NotImplementedException();
        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Listar todos os objetos generos
        /// </summary>
        /// <returns> Lista de objetos </returns>
        public List<GeneroDomain> ListarTodos()
        {
            //cria uma lista de objetos do tipo genero
            List<GeneroDomain> listaGeneros = new List<GeneroDomain>();

            //declara a Sqlconnetion passando a string de conexao como parametro
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                //declara a instrucao a ser executada
                string querrySelectAll = "SELECT IdGenero, Nome FROM Genero";

                //Abre a conexao com o banco de dados
                con.Open();

                //Declara o SqlDataReader para percorrer a tabela do banco de dados
                SqlDataReader rdr;

                //declara o SqlCommand passando a querry que sera executada e a conexao com o banco
                using (SqlCommand cmd = new SqlCommand(querrySelectAll, con))
                {
                    //executa a querry e armazena os dados do rdr
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        GeneroDomain genero = new GeneroDomain()
                        {
                            //atribui a propriedade IdGenero o valor sugerido no rdr
                            IdGenero = Convert.ToInt32(rdr[0]),
                            //atribui a propriedade Nome o valor sugerido no rdr
                            Nome = rdr["Nome"].ToString()
                        };

                        listaGeneros.Add(genero);
                    }
                }
            }

                return listaGeneros;
        }
    }
}
