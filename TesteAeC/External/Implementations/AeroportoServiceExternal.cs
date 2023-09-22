using Microsoft.IdentityModel.Tokens;
using TesteAeC.Data.Dtos.Aeroporto;

namespace TesteAeC.External.Implementations
{
    public class AeroportoServiceExternal : IAeroportoServiceExternal
    {
        static HttpClient _httpClient = new HttpClient();
        private const string baseAdress = "https://brasilapi.com.br/api/cptec/v1/clima/aeroporto";

        public async Task<ReadAeroporto?> RetornaAeroportoPorCodigo(string codigo)
        {
            try
            {   
                var response = await _httpClient.GetFromJsonAsync<ReadAeroporto>($"{baseAdress}/{codigo}");

                if (response != null)
                    return response;
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }
    }
}
