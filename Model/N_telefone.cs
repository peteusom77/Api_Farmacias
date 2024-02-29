using System.ComponentModel.DataAnnotations.Schema;

namespace Api_Farmacias.Model
{
    [Table("numero_telefone")]
    public class N_telefone
    {
        public int Id {get;set;}
        public int telefone {get;set;}   
    }
}