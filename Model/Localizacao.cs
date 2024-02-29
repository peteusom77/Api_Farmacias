using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Api_farmacias.Model;

namespace Api_farmancias.Model
{
    [Table("localizacao")]
    public class Localizacao
    {
        [Key]
        [Column("id")]
        public int Id {get;set;}
        [Column("codigo_ip")]
        public int Codigo_ip{get;set;}
        [Column("id_farmacia")]
        public int Id_farmacia{get;set;}


    }
}