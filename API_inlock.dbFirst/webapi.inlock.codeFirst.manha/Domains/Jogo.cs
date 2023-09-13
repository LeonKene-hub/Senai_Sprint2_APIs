using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.inlock.codeFirst.manha.Domains
{
    [Table("Jogo")]
    public class Jogo
    {
        [Key]
        public Guid IdJogo { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "Nome do jogo e obrigatorio")]
        public string? Nome { get; set; }

        [Column(TypeName = "TEXT")]
        [Required(ErrorMessage = "Descricao obrigatorio")]
        public int Descricao { get; set; }

        [Column(TypeName = "DATE")]
        [Required(ErrorMessage = "Data de lancamento obrigatoria")]
        public DateTime? DataLancamento { get; set; }
    }
}
