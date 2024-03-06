using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Api_Farmacias.Model;

namespace Api_Farmancias.Model
{
    
    public class LocalizacaoDTO
    {
        [JsonIgnore]
        public int Id {get;set;}
        public string? Codigo_ip{get;set;}
        [JsonIgnore]
        public int farmacia_id{get;set;}


    }
}