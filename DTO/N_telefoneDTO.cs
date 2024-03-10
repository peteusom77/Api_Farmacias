using System.Text.Json.Serialization;

namespace Api_Farmacias.DTO
{
    public class N_telefoneDTO
    {
       
        public int telefone {get;set;}   
        [JsonIgnore]
        public int farmacia_id{get;set;}
    }
}