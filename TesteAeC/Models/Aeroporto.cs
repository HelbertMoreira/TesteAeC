using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TesteAeC.Models
{
    [Table("Aeroporto")]
    public class Aeroporto
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(4, ErrorMessage = "O contúdo da mensagem não pode ter mais que 4 caracteres")]
        public string CodigoIcao { get; set; }
        public DateTime AtualizadoEm { get; set; }
        public int PressaoAtmosferica { get; set; }
        public string Visibilidade { get; set; }
        public int Vento { get; set; }
        public int DirecaoVento { get; set; }
        public int Umidade { get; set; }
        public string Condicao { get; set; }
        public string CondicaoDesc { get; set; }
        public int Temp { get; set; }
    }
}
