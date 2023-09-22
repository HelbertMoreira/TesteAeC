using AutoMapper;
using TesteAeC.Data.Dtos.Previsoes;
using TesteAeC.Models;

namespace TesteAeC.Profiles
{
    public class ClimaProfile : Profile
    {
        public ClimaProfile()
        {
            CreateMap<ReadClima, Clima>()
                .ForMember(dest => dest.Data, m => m.MapFrom(src => src.data))
                .ForMember(dest => dest.Condicao, m => m.MapFrom(src => src.condicao))
                .ForMember(dest => dest.CondicaoDesc, m => m.MapFrom(src => src.condicao_desc))
                .ForMember(dest => dest.Min, m => m.MapFrom(src => src.min))
                .ForMember(dest => dest.Max, m => m.MapFrom(src => src.max))
                .ForMember(dest => dest.IndiceUv, m => m.MapFrom(src => src.indice_uv));
        }
    }
}
