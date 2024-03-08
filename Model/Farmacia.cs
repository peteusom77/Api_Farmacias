using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
namespace Api_Farmacias.Model
{
    [Table("farmacia")]
    public class Farmacia
    {
        [Key]
        [Column("id")]
        public int Id {get;set;}
        [Column("nome")]
        public string? Nome {get;set;}
        [Column("nif")]
        public long NIF {get;set;}
        [Column("email")]
        public string? Email{get;set;}
        [Column("horadeabertura")]
        public DateTime HoraDeabertura{get;set;}
        [Column("horadeencerramento")]
        public DateTime HoraDeEncerramento{get;set;}
        [JsonIgnore]
        public List<Localizacao>? localizacaos{get;set;}
        [JsonIgnore]
        public List<Direcao>? direcaos{get;set;}
        [JsonIgnore]
        public List<N_telefone>? n_Telefones{get;set;}
    }
}