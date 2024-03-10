using Api_Farmacias.DTO;
using Api_Farmacias.Model;
using AutoMapper;


namespace Api_Farmacias.Mapping
{
    public class FarmaciaMapping:Profile
    {
        public FarmaciaMapping()
        {
            CreateMap<Farmacia, FarmaciaDTO>()
            .ReverseMap()
            .ForMember(dest => dest.Id, opt => opt.Ignore());
            CreateMap<FarmaciaDTO,Farmacia>();
            CreateMap<N_telefoneDTO,N_telefone>().ReverseMap();
            CreateMap<Localizacao,LocalizacaoDTO>()
            .ReverseMap();
        }
    }
}