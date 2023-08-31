using WebAPI.Filmes.manha.Domains;

namespace WebAPI.Filmes.manha.Interfaces
{
    public interface IUsuarioRepository
    {
        public UsuarioDomain Login(string email, string senha);
    }
}
