using AutoMapper;
using TesteAeC.Data.Dtos.Cidades;
using TesteAeC.Models;

namespace TesteAeC.Profiles
{
    public class CidadeProfile : Profile
    {
        public CidadeProfile()
        {
            CreateMap<ReadCidadeClima, Cidade>()
                .ForMember(dest => dest.NomeCidade, m => m.MapFrom(src => src.cidade))
                .ForMember(dest => dest.Estado, m => m.MapFrom(src => src.estado))
                .ForMember(dest => dest.AtualizadoEm, m => m.MapFrom(src => src.atualizado_em))
                .ForMember(dest => dest.Clima, m => m.MapFrom(src => src.clima)).ReverseMap();

            CreateMap<ReadCidade, Cidade>()
                .ForMember(dest => dest.NomeCidade, m => m.MapFrom(src => src.nome))
                .ForMember(dest => dest.Estado, m => m.MapFrom(src => src.estado))
                .ForMember(dest => dest.AtualizadoEm, m => m.MapFrom(src => src.atualizado_em)).ReverseMap();

            //CreateMap<Cidade, ReadCidadeClima>()
            //    .ForMember(dest => dest.cidade, m => m.MapFrom(src => src.NomeCidade))
            //    .ForMember(dest => dest.estado, m => m.MapFrom(src => src.Estado))
            //    .ForMember(dest => dest.atualizado_em, m => m.MapFrom(src => src.AtualizadoEm));
            //.ForMember(dest => dest.clima, m => m.MapFrom(src => src.Clima));
        }
    }
}
