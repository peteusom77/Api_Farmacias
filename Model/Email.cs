using System.ComponentModel.DataAnnotations.Schema;

namespace Api_Farmacias.Model
{
    [Table("email")]
    public class Email
    {
        public string? email {get;set;}
    }
}