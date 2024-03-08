using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Api_Farmacias.Model
{
    [Table("direcao")]
    public class Direcao
    {
        [Key]
        [Column("id")]
        public int Id {get;set;}
        [Column("provincia")]
        public string? Provincia {get;set;}
        [Column("municipio")]
        public string? Municipio{get;set;}
        [Column("rua")]
        public string? Rua{get;set;}
        [Column("ponto_de_referencia")]
        public string? Ponto_de_referencia{get;set;}
        [ForeignKey("farmacia")]
        [Column("farmacia_id")]
        public int farmacia_id {get;set;}
        public Farmacia? farmacia{get;set;}
    }
}