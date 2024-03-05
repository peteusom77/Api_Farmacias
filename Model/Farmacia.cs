using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Api_Farmacias.Model;
using Api_Farmancias.Model;
using Microsoft.VisualBasic;

namespace Api_Farmacias.Model
{
    [Table("farmacia")]
    public class Farmacia
    {
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
        public ICollection<Localizacao>? Localizacoes { get; set; }
    }
}