using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Api_Farmacias.Model
{
    [Table("n_telefone")]
    public class N_telefone
    {
        [Key]
        [Column("id")]
        public int Id {get;set;}
        [Column("telefone")]
        public int telefone {get;set;}  
        [ForeignKey("farmacia")]
        [Column("farmacia_id")]
        public int farmacia_id {get;set;}
        public Farmacia? farmacia{get;set;} 
    }
}