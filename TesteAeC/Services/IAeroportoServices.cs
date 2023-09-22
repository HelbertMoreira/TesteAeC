using TesteAeC.Data.Dtos.Aeroporto;

namespace TesteAeC.Services
{
    public interface IAeroportoServices
    {
        Task<ReadAeroporto> SalvarAeroportoConsultado(ReadAeroporto consultaAeroporto);
        Task<List<ReadAeroporto?>> ListarConsultasRealizadasEmAeroportos();
    }
}
