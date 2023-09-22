using TesteAeC.Models;

namespace TesteAeC.Data.Dtos.Previsoes
{
    public class ReadClima
    {
        public DateTime data { get; set; }
        public string condicao { get; set; }
        public int min { get; set; }
        public int max { get; set; }
        public int indice_uv { get; set; }
        public string condicao_desc { get; set; }
    }
}
