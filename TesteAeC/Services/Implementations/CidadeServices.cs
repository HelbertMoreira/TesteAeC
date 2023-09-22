using AutoMapper;
using FluentResults;
using Microsoft.EntityFrameworkCore;
using Serilog;
using TesteAeC.Data;
using TesteAeC.Data.Dtos.Cidades;
using TesteAeC.Models;

namespace TesteAeC.Services.Implementations
{
    public class CidadeServices : ICidadeServices
    {
        private readonly IMapper _mapper;
        private readonly AplicationContext _context;

        public CidadeServices(IMapper mapper, AplicationContext context)
        {
            _mapper = mapper;
            _context = context;
        }


        public async Task<Result> SalvarCidadeConsultada(ReadCidadeClima localidade)
        {
            try
            {
                var cidade = _mapper.Map<Cidade>(localidade);
                await _context.Localidades.AddAsync(cidade);
                await _context.SaveChangesAsync();

                Log.Information("Inserindo LOG de sucesso");
                return Result.Ok();

            }
            catch (Exception ex)
            {
                Log.Error("Erro ao salvar consulta em clima por CIDADES. Erro: " + ex.Message);
                return Result.Fail($"Erro ao salvar consulta em AEROPORTO. Erro: {ex.Message}");
            }
        }
    }
}
