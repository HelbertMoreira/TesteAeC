using System.Text.Json.Serialization;

namespace TesteAeC.Models
{
    public class Clima
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public string Condicao { get; set; }
        public int Min { get; set; }
        public int Max { get; set; }
        public int IndiceUv { get; set; }
        public string CondicaoDesc { get; set; }
        public int CidadeId { get; set; }
        [JsonIgnore]
        public virtual Cidade Cidade { get; set; }
    }
}
