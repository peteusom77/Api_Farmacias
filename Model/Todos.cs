using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api_Farmancias.Model;

namespace Api_Farmacias.Model
{
    public class Todos
    {
        public required FarmaciaDTO farmaciaDTO{get;set;}
        public required LocalizacaoDTO localizacaoDTO{get;set;}
    }
}