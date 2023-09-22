using AutoMapper;
using TesteAeC.Data.Dtos.Aeroporto;
using TesteAeC.Models;

namespace TesteAeC.Profiles
{
    public class AeroportoProfile : Profile
    {
        public AeroportoProfile()
        {
            CreateMap<ReadAeroporto, Aeroporto>()
                .ForMember(dest => dest.AtualizadoEm, m => m.MapFrom(src => src.atualizado_em))
                .ForMember(dest => dest.Temp, m => m.MapFrom(src => src.temp))
                .ForMember(dest => dest.CodigoIcao, m => m.MapFrom(src => src.codigo_icao))
                .ForMember(dest => dest.Condicao, m => m.MapFrom(src => src.condicao))
                .ForMember(dest => dest.CondicaoDesc, m => m.MapFrom(src => src.condicao_desc))
                .ForMember(dest => dest.Umidade, m => m.MapFrom(src => src.umidade))                               
                .ForMember(dest => dest.PressaoAtmosferica, m => m.MapFrom(src => src.pressao_atmosferica))                               
                .ForMember(dest => dest.DirecaoVento, m => m.MapFrom(src => src.direcao_vento))                               
                .ForMember(dest => dest.Visibilidade, m => m.MapFrom(src => src.visibilidade));
        }
    }
}
