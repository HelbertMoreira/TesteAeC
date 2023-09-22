using AutoMapper;
using FluentResults;
using Serilog;
using TesteAeC.Data;
using TesteAeC.Data.Dtos.Aeroporto;
using TesteAeC.Models;

namespace TesteAeC.Services.Implementations
{
    public class AeroportoServices : IAeroportoServices
    {
        private readonly IMapper _mapper;
        private readonly AplicationContext _context;

        public AeroportoServices(IMapper mapper, AplicationContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<Result> SalvarAeroportoConsultado(ReadAeroporto consultaAeroporto)
        {
            try
            {
                var aeroporto = _mapper.Map<Aeroporto>(consultaAeroporto);
                await _context.Aeroportos.AddAsync(aeroporto);
                await _context.SaveChangesAsync();

                Log.Information("Inserindo LOG de sucesso");
                return Result.Ok();

            }
            catch (Exception ex)
            {
                Log.Error("Erro ao salvar consulta em AEROPORTO. Erro: " + ex.Message);
                return Result.Fail($"Erro ao salvar consulta em AEROPORTO. Erro: {ex.Message}");
            }
        }
    }
}
