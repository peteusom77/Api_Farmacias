using System.Text.Json.Serialization;

namespace Api_Farmacias.Model
{
    public class DirecaoDTO
    {
        
        public string? Provincia {get;set;}
        public string? Municipio{get;set;}
        public string? Rua{get;set;}
        public string? Ponto_de_referencia{get;set;}
        [JsonIgnore]
        public int farmacia_id{get;set;}

    }
}