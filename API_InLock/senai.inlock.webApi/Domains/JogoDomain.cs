using System.ComponentModel.DataAnnotations;

namespace senai.inlock.webApi.Domains
{
    /// <summary>
    /// Domain de jogo com seus atributos
    /// </summary>
    public class JogoDomain
    {
        /// <summary>
        /// Identificador unico de jogo
        /// </summary>
        public int IdJogo { get; set; }

        /// <summary>
        /// ID do estudio criador do jogo
        /// </summary>
        [Required(ErrorMessage = "Estudio obrigatorio")]
        public int IdEstudio { get; set; }

        /// <summary>
        /// Nome do jogo
        /// </summary>
        [Required(ErrorMessage = "Nome obrigatorio")]
        public string ?Nome { get; set; }

        /// <summary>
        /// Data de lançamento do jogo (precisa de tratamento o dado para exibir)
        /// </summary>
        [Required(ErrorMessage = "Data de lancamento obrigatorio")]
        public DateTime DataLancamento { get; set; }

        /// <summary>
        /// Descrição do jogo a venda
        /// </summary>
        public string ?Descricao { get; set; }

        /// <summary>
        /// Valor (preço) de venda do jogo
        /// </summary>
        [Required(ErrorMessage = "Valor obrigatorio")]
        public double Valor { get; set; }

        /// <summary>
        /// Objeto de estudio para trazer dados do estudio criador do jogo
        /// </summary>
        public EstudioDomain ?Estudio { get; set; }
    }
}
