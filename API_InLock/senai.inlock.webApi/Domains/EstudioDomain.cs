using System.ComponentModel.DataAnnotations;

namespace senai.inlock.webApi.Domains
{
    /// <summary>
    /// Domain de estudio e seus atributos
    /// </summary>
    public class EstudioDomain
    {
        /// <summary>
        /// Identificador unico de estudio
        /// </summary>
        public int IdEstudio { get; set; }
        /// <summary>
        /// Nome do estudio criador do jogo
        /// </summary>
        [Required(ErrorMessage = "Nome necessario")]
        public string ?Nome { get; set; }
    }
}
