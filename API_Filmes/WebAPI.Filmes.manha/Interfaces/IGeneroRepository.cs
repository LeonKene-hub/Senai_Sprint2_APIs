using WebAPI.Filmes.manha.Domains;

namespace WebAPI.Filmes.manha.Interfaces
{
    /// <summary>
    /// Interface responsavel pelo repositorio GeneroRepository
    /// Definir os metodos que serao implementados pelo GeneroRepository
    /// </summary>
    public interface IGeneroRepository
    {
        //tipoRetorno NomeMetodo (TipoParametro nomeParametro)

        void Cadastrar(GeneroDomain novoGenero);
        List<GeneroDomain> ListarTodos();
        void AtualizarIdCorpo(GeneroDomain genero);
        void Deletar(int id);
    }
}
