﻿using System.Data.SqlClient;
using WebAPI.Filmes.manha.Domains;
using WebAPI.Filmes.manha.Interfaces;

namespace WebAPI.Filmes.manha.Repositories
{
    public class GeneroRepository : IGeneroRepository
    {
        /// <summary>
        /// String de conexão com o banco de dados que recebe os seguintes parametros
        /// Data Source: Nome do servidor
        /// Initial Catalog: Nome do bando de dados
        /// 
        /// --autenticação sql server:
        /// User: Usuario de acesso ao banco
        /// pwd: Senha de acesso ao banco
        /// 
        /// --autenticação windows:
        /// Integrated Security = true
        /// </summary>
        private string stringConexao = "Data Source = NOTE20-S15; Initial Catalog = Filmes; User Id = sa; pwd = Senai@134; TrustServerCertificate = true";

        //**************************************  Atualizar Id corpo  **************************************

        public void AtualizarIdCorpo(GeneroDomain genero)
        {
            throw new NotImplementedException();
        }

        //**************************************  Atualizar Id URL  **************************************

        public void AtualizarIdURL(int id, GeneroDomain genero)
        {
            throw new NotImplementedException();
        }

        //**************************************  Buscar por ID  **************************************

        public GeneroDomain BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        //**************************************  Cadastrar genero  **************************************

        /// <summary>
        /// Cadastrar um genero
        /// </summary>
        /// <param name="novoGenero"> objeto com as informacoes que serao cadastrados</param>
        public void Cadastrar(GeneroDomain novoGenero)
        {
            //declara a conexao passando a string de conexao como parametro
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                //declara a querry que sera executaca
                string querryInsert = "INSERT INTO Genero(Nome) VALUES (' "+ novoGenero.Nome + " ')";

                //declara o SqlCommand passando a query que sera executada e a conexao do bd
                using (SqlCommand cmd = new SqlCommand(querryInsert, con))
                {
                    //abre o banco de dados
                    con.Open();
                    //executar a querry (querry insert)
                    cmd.ExecuteNonQuery();
                }
            }
        }

        //**************************************  Deletar  **************************************

        /// <summary>
        /// Deletar um genero
        /// </summary>
        /// <param name="id">id do genero a ser deletado</param>
        /// <exception cref="NotImplementedException"></exception>
        public void Deletar(int id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querryDelete = "DELETE FROM Filme WHERE IdGenero = @IdDelete";

                using (SqlCommand cmd = new SqlCommand(querryDelete, con))
                {
                    cmd.Parameters.AddWithValue("IdDelete", id);  

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        //**************************************  Listar todos os generos  **************************************

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
