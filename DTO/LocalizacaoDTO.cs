using System.Text.Json.Serialization;
namespace Api_Farmacias.Model
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