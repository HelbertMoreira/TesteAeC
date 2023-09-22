using FluentResults;
using TesteAeC.Data.Dtos.Aeroporto;

namespace TesteAeC.Services
{
    public interface IAeroportoServices
    {
        Task<Result> SalvarAeroportoConsultado(ReadAeroporto consultaAeroporto);
    }
}
