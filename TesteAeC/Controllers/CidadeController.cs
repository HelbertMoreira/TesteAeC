using Microsoft.AspNetCore.Mvc;
using TesteAeC.Data.Dtos.Cidades;
using TesteAeC.External;
using TesteAeC.Services;

namespace TesteAeC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CidadeController : ControllerBase
    {
        private readonly ICidadeServiceExternal _cidadeExternalServices;
        private readonly ICidadeServices _cidadeServices;

        public CidadeController(ICidadeServiceExternal cidadeExternalServices, ICidadeServices cidadeServices)
        {
            _cidadeExternalServices = cidadeExternalServices;
            _cidadeServices = cidadeServices;
        }

        [HttpGet]
        [Route("listar_cidades")]
        public async Task<List<ReadCidade>> ListarCidades()
        {
            return await _cidadeExternalServices.RetornaListaDeCidades();
        }

        [HttpGet]
        [Route("listar_consultas_realizadas")]
        public async Task<List<ReadCidade?>> ListarCidadesConsultadas()
        {
            return await _cidadeServices.ListarConsultasRealizadasEmCidades();
        }


        [HttpGet]
        [Route("consultar_clima_por_codigo_cidade")]
        public async Task<ReadCidadeClima?> ConsultaCidade(int code)
        {
            var resultado = await _cidadeExternalServices.RetornaCidadePorCodigo(code);

            if (resultado != null)
                await _cidadeServices.SalvarCidadeConsultada(resultado);

            return resultado;
        }
    }
}
