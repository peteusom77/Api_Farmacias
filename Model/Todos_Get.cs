using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api_Farmacias.DTO;

namespace Api_Farmacias.Model
{
    public class Todos_Get
    {
        public FarmaciaDTO? FFarmaciaDTO{get;set;}
        public List<LocalizacaoDTO>? LLocalizacaos{get;set;}
        public List<DirecaoDTO>? DDirecaoDTOs {get;set;}
        public List<N_telefoneDTO>? NN_TelefoneDTOs{get;set;}
    }
}