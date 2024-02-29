using System.ComponentModel.DataAnnotations.Schema;

namespace Api_Farmacias.Model
{
    [Table("email")]
    public class Email
    {
        [Column("id")]
        public int  Id{get;set;}
        public string? email {get;set;}
        [Column("id_farmacia")]
        public int Id_farmacia {get;set;}
    }
}