using System.ComponentModel.DataAnnotations;

namespace senai.inlock.webApi.Domains
{
    /// <summary>
    /// Domain de usuario
    /// </summary>
    public class UsuarioDomain
    {
        /// <summary>
        /// Identificador unico do usuario
        /// </summary>
        public int IdUsuario { get; set; }

        /// <summary>
        /// Identificador do tipo de usuario usado pelo usuario para autenticação e autorização
        /// </summary>
        [Required(ErrorMessage = "Id do tipo de usuario obrigatorio")]
        public int IdTipoUsuario { get; set; }

        /// <summary>
        /// Endereço email do usuario (autenticação)
        /// </summary>
        [Required(ErrorMessage = "Email obrigatorio")]
        public string ?Email { get; set;}

        /// <summary>
        /// Senha definida e utilizada pelo usuario (autenticação)
        /// </summary>
        [Required(ErrorMessage = "Senha obrigatoria")]
        public string ?Senha { get; set;}

        /// <summary>
        /// Objeto de tipo de usuario para trazer informações para usuario
        /// </summary>
        public TiposUsuarioDomain ?TipoUsuarioDomain { get; set; }
    }
}
