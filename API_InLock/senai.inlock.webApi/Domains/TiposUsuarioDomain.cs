using System.ComponentModel.DataAnnotations;

namespace senai.inlock.webApi.Domains
{
    /// <summary>
    /// Domain dos tipos de usuarios presentes no sistema
    /// </summary>
    public class TiposUsuarioDomain
    {
        /// <summary>
        /// Identificador unico para o tipo de usuario, sera usado para autorização
        /// </summary>
        public int IdTipoUsuario { get; set; }

        /// <summary>
        /// Titulo (nome) do tipo de usuario que contem permissões unicas
        /// </summary>
        [Required(ErrorMessage = "Titulo de tipo de usuario obrigatorio")]
        public string ?Titulo { get; set; }
    }
}
