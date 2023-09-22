using AutoMapper;
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

        public Task<List<ReadAeroporto?>> ListarConsultasRealizadasEmAeroportos()
        {
            throw new NotImplementedException();
        }

        public async Task<ReadAeroporto> SalvarAeroportoConsultado(ReadAeroporto consultaAeroporto)
        {
            try
            {
                var aeroporto = _mapper.Map<Aeroporto>(consultaAeroporto);
                await _context.Aeroportos.AddAsync(aeroporto);
                await _context.SaveChangesAsync();
                
                return _mapper.Map<ReadAeroporto>(aeroporto);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
