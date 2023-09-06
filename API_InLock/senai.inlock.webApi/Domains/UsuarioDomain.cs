using System.ComponentModel.DataAnnotations;

namespace senai.inlock.webApi.Domains
{
    public class UsuarioDomain
    {
        public int IdUsuario { get; set; }
        [Required(ErrorMessage = "Id do tipo de usuario obrigatorio")]
        public int IdTipoUsuario { get; set; }
        [Required(ErrorMessage = "Email obrigatorio")]
        public string ?Email { get; set;}
        [Required(ErrorMessage = "Senha obrigatoria")]
        public string ?Senha { get; set;}
        public TiposUsuarioDomain ?TipoUsuarioDomain { get; set; }
    }
}
