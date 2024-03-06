using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api_Farmacias.DTO;
using Api_Farmacias.Model;
using Api_Farmancias.Model;
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
            CreateMap<Localizacao,LocalizacaoDTO>()
            .ReverseMap();
        }
    }
}

