namespace Api_Farmancias.DTO
{
    public class FarmaciaDTO
    {
        public string? Nome {get;set;}
        
        public long NIF {get;set;}
        public string? Email{get;set;}
        
        public DateTime HoraDeabertura{get;set;}
        
        public DateTime HoraDeEncerramento{get;set;}
    }
}