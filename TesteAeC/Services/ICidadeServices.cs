
using TesteAeC.Data.Dtos.Cidades;

namespace TesteAeC.Services
{
    public interface ICidadeServices
    {
        Task<ReadCidade> SalvarCidadeConsultada(ReadCidadeClima localidade);
        Task<List<ReadCidade?>> ListarConsultasRealizadasEmCidades();
    }
}
