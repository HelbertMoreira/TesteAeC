using TesteAeC.Data.Dtos.Previsoes;

namespace TesteAeC.Data.Dtos.Cidades
{
    public class ReadCidadeClima
    {
        public string cidade { get; set; }
        public string estado { get; set; }
        public DateTime atualizado_em { get; set; }
        public List<ReadClima> clima { get; set; }
    }
}
