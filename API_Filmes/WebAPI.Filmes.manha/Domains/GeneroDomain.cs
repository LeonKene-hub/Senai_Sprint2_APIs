using System.ComponentModel.DataAnnotations;

namespace WebAPI.Filmes.manha.Domains
{
    /// <summary>
    /// Classe que representa a entidade (tabela) Genero
    /// </summary>
    public class GeneroDomain
    {
        [Required(ErrorMessage = "O nome do genero e obrigatorio")]
        public int IdGenero { get; set; }
        public string? Nome { get; set; }

        public static implicit operator GeneroDomain(FilmeDomain v)
        {
            throw new NotImplementedException();
        }
    }
}