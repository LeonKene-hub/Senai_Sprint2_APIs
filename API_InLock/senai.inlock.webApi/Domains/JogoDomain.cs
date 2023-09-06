using System.ComponentModel.DataAnnotations;

namespace senai.inlock.webApi.Domains
{
    public class JogoDomain
    {
        public int IdJogo { get; set; }
        [Required(ErrorMessage = "Estudio obrigatorio")]
        public int IdEstudio { get; set; }
        [Required(ErrorMessage = "Nome obrigatorio")]
        public string ?Nome { get; set; }
        [Required(ErrorMessage = "Data de lancamento obrigatorio")]
        public DateTime DataLancamento { get; set; }
        public string ?Descricao { get; set; }
        [Required(ErrorMessage = "Valor obrigatorio")]
        public double Valor { get; set; }
        public EstudioDomain Estudio { get; set; }
    }
}
