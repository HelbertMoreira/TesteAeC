using TesteAeC.Data.Dtos.Cidades;

namespace TesteAeC.External.Implementations
{
    public class CidadeServiceExternal : ICidadeServiceExternal
    {
        static HttpClient _httpClient = new HttpClient();
        private const string baseAdress = "https://brasilapi.com.br/api/cptec/v1/cidade";
        private const string baseAdressClima = "https://brasilapi.com.br/api/cptec/v1/clima/previsao";


        public async Task<List<ReadCidade>> RetornaListaDeCidades()
        {
            try
            {
                var response = await _httpClient.GetFromJsonAsync<List<ReadCidade>>(baseAdress);

                if (response != null)
                    return response;
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ReadCidadeClima?> RetornaCidadePorCodigo(int codigo)
        {
            try
            {
                var response = await _httpClient.GetFromJsonAsync<ReadCidadeClima>($"{baseAdressClima}/{codigo}");

                if (response != null)
                    return response;
                return response;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        
    }
}
