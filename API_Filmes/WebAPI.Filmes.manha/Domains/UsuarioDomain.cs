using System.ComponentModel.DataAnnotations;

namespace WebAPI.Filmes.manha.Domains
{
    public class UsuarioDomain
    {
        public int IdUsuario { get; set; }
        [Required(ErrorMessage = "email e obrigatorio")]
        public string Email { get; set; }
        [Required(ErrorMessage = "senha e obrigatorio")]
        public string Senha { get; set; }
        public int Permissao { get; set; }
    }
}
