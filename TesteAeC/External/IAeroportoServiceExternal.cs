using TesteAeC.Data.Dtos.Aeroporto;

namespace TesteAeC.External
{
    public interface IAeroportoServiceExternal
    {
        Task<ReadAeroporto> RetornaAeroportoPorCodigo(string codigo);
    }
}
