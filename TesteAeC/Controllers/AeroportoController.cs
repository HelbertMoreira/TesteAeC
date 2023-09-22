
using Microsoft.AspNetCore.Mvc;
using TesteAeC.Data.Dtos.Aeroporto;
using TesteAeC.External;
using TesteAeC.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TesteAeC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AeroportoController : ControllerBase
    {
        private readonly IAeroportoServiceExternal _aeroportoExternalServices;
        private readonly IAeroportoServices _aeroportoServices;

        public AeroportoController(IAeroportoServiceExternal aeroportoExternalServices, IAeroportoServices aeroportoServices)
        {
            _aeroportoExternalServices = aeroportoExternalServices;
            _aeroportoServices = aeroportoServices;
        }

        [HttpGet("listar_consultas_realizadas")]
        public async Task<List<ReadAeroporto?>> ListarAeroportosSalvos()
        {
            return await _aeroportoServices.ListarConsultasRealizadasEmAeroportos();
        }

        
        [HttpGet("consultar_clima_aeroporto")]
        public async Task<ReadAeroporto?> ConsultaAeroporto(string code)
        {
            var resultado =  await _aeroportoExternalServices.RetornaAeroportoPorCodigo(code);

            if (resultado != null)
                await _aeroportoServices.SalvarAeroportoConsultado(resultado);

            return resultado;
        }
    }
}
