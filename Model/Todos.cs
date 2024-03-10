using Api_Farmacias.DTO;
namespace Api_Farmacias.Model
{
    public class Todos
    {
        public required FarmaciaDTO farmaciaDTO{get;set;}
        public required LocalizacaoDTO localizacaoDTO {get;set;}
        public required N_telefoneDTO n_TelefoneDTO{get;set;}
        public required DirecaoDTO  direcaoDTO{get;set;}
    }
}