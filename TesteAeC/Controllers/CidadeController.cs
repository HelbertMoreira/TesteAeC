using FluentResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Text.RegularExpressions;
using TesteAeC.Data.Dtos.Aeroporto;
using TesteAeC.Data.Dtos.Cidades;
using TesteAeC.External;
using TesteAeC.Services;
using TesteAeC.Services.Implementations;

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
        [Route("consultar_clima_por_codigo_cidade")]
        public async Task<Result<ReadCidadeClima?>> ConsultaCidade(string code)
        {
            
            if (Regex.IsMatch(code, @"^\d+$")  && !string.IsNullOrEmpty(code.ToString()))
            {
                ReadCidadeClima resultado = await _cidadeExternalServices.RetornaCidadePorCodigo(Convert.ToInt32(code));

                if (!string.IsNullOrEmpty(resultado.cidade))
                {
                    var resultadobd = await _cidadeServices.SalvarCidadeConsultada(resultado);

                    if (resultadobd.IsSuccess)
                        return Result.Ok(resultado);
                    return Result.Fail("Erro ao salvar registro na base de dados");
                }
            }
            return Result.Fail("Código informado deve conter apenas números e não ser nulo");
        }
    }
}
