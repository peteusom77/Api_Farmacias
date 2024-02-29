using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Api_Farmacias.Model;
using Api_farmancias.Model;
using Microsoft.VisualBasic;

namespace Api_farmacias.Model
{
    [Table("farmacia")]
    public class Farmacia
    {
/* public Farmacia()
        {
            Localizacaos = new HashSet<Localizacao>();
        }
*/
        [Column("id")]
        public int Id {get;set;}
        [Column("nome")]
        public string? Nome {get;set;}
        [Column("nif")]
        public long NIF {get;set;}
        public string? Email{get;set;}
        [Column("horadeabertura")]
        public DateTime HoraDeabertura{get;set;}
        [Column("horadeencerramento")]
        public DateTime HoraDeEncerramento{get;set;}
   

    }
}