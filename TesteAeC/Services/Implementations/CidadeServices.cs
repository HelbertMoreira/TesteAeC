using AutoMapper;
using Microsoft.EntityFrameworkCore;
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

        public async Task<List<ReadCidade?>> ListarConsultasRealizadasEmCidades()
        {
            try
            {
                var result = await _context.Localidades
                    .Include(x => x.Clima)
                    .ToListAsync();
                return _mapper.Map<List<ReadCidade?>>(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ReadCidade> SalvarCidadeConsultada(ReadCidadeClima localidade)
        {
            try
            {
                var cidade = _mapper.Map<Cidade>(localidade);
                await _context.Localidades.AddAsync(cidade);
                await _context.SaveChangesAsync();

                return _mapper.Map<ReadCidade>(cidade);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
