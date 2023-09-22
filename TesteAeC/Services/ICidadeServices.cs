
using FluentResults;
using TesteAeC.Data.Dtos.Cidades;

namespace TesteAeC.Services
{
    public interface ICidadeServices
    {
        Task<Result> SalvarCidadeConsultada(ReadCidadeClima localidade);
    }
}
