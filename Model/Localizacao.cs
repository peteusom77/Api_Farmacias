using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Api_Farmacias.Model;
namespace Api_Farmancias.Model
{
    [Table("localizacao")]
    
    public class Localizacao
    {
        [Key]
        [Column("id")]
        public int Id {get;set;}
        [Column("codigo_ip")]
        public string? Codigo_ip{get;set;}
        [ForeignKey("farmacia")]
        [Column("farmacia_id")]
        public int farmacia_id {get;set;}
        public Farmacia? farmacia{get;set;}
    }
}