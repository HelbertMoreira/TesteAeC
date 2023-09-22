namespace TesteAeC.Models
{
    public class Cidade
    {
        public int Id { get; set; }
        public string NomeCidade { get; set; }
        public string Estado { get; set; }
        public DateTime AtualizadoEm { get; set; }
        public List<Clima> Clima { get; set; }
    }
}
