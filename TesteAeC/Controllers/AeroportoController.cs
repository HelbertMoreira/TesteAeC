
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;
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

        
        [HttpGet("consultar_clima_aeroporto")]
        public async Task<Result> ConsultaAeroporto(string code)
        {             
            if (Regex.IsMatch(code, @"(?i)^[a-záéíóúõãçàâêôA-ZÁÉÍÓÚÕÃÇÂÊÔ]+$") && !string.IsNullOrEmpty(code))
            {
                ReadAeroporto resultado = await _aeroportoExternalServices.RetornaAeroportoPorCodigo(code);

                if (!string.IsNullOrEmpty(resultado.codigo_icao))
                {
                    var resultadobd = await _aeroportoServices.SalvarAeroportoConsultado(resultado);

                    if (resultadobd.IsSuccess)
                        return Result.Ok();
                    return Result.Fail("Erro ao salvar registro na base de dados");
                }
            }
            return Result.Fail("Código informado deve conter apenas caracteres e não ser nulo");
        }
    }
}
