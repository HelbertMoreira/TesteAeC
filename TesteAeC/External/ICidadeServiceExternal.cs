using TesteAeC.Data.Dtos.Aeroporto;
using TesteAeC.Data.Dtos.Cidades;

namespace TesteAeC.External
{
    public interface ICidadeServiceExternal
    {
        Task<List<ReadCidade>> RetornaListaDeCidades();
        Task<ReadCidadeClima> RetornaCidadePorCodigo(int codigo);
    }
}
