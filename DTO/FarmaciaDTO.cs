using System.Text.Json.Serialization;


namespace Api_Farmacias.Model
{
   
    public class FarmaciaDTO
    {
        [JsonIgnore]
        public int Id {get;set;}
        public string? Nome {get;set;}
       
        public long NIF {get;set;}
        public string? Email{get;set;}
        
        public DateTime HoraDeabertura{get;set;}
  
        public DateTime HoraDeEncerramento{get;set;}
    }
}