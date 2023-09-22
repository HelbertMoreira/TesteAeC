using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TesteAeC.Models
{
    [Table("Cidade")]
    public class Cidade
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(30, ErrorMessage = "O conteúdo da mensagem não pode ter mais que 30 caracteres")]
        [Column("Cidade")]
        public string NomeCidade { get; set; }
        public string Estado { get; set; }
        public DateTime AtualizadoEm { get; set; }
        public List<Clima> Clima { get; set; }
    }
}
