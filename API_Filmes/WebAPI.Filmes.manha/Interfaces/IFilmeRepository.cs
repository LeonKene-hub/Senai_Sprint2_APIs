using WebAPI.Filmes.manha.Domains;

namespace WebAPI.Filmes.manha.Interfaces
{
    public interface IFilmeRepository
    {
        void Cadastrar(FilmeDomain novoFilme);

        List<FilmeDomain> ListarTodos();

        void AtualizarIdCorpo(FilmeDomain novoFilme);

        void AtualizarIdRUL(int id, FilmeDomain filme);

        void Deletar(int id);

        FilmeDomain BuscarPorId(int id);
    }
}
