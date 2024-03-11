using Api_Farmacias.DTO;
using Api_Farmacias.Model;
using AutoMapper;


namespace Api_Farmacias.Mapping
{
    public class FarmaciaMapping:Profile
    {
        public FarmaciaMapping()
        {
            CreateMap<Farmacia, FarmaciaDTO>() .ReverseMap();
            CreateMap<FarmaciaDTO,Farmacia>();
            CreateMap<DirecaoDTO,Direcao>().ReverseMap();
            CreateMap<N_telefoneDTO,N_telefone>().ReverseMap();
            CreateMap<Localizacao,LocalizacaoDTO>().ReverseMap();
        }
    }
}