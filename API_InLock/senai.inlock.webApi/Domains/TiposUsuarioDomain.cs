using System.ComponentModel.DataAnnotations;

namespace senai.inlock.webApi.Domains
{
    public class TiposUsuarioDomain
    {
        public int IdTipoUsuario { get; set; }
        [Required(ErrorMessage = "Titulo de tipo de usuario obrigatorio")]
        public string ?Titulo { get; set; }
    }
}
