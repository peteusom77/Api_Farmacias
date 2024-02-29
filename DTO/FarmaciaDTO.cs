using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Api_Farmacias.Model;
using Api_Farmancias.Model;
using Microsoft.VisualBasic;

namespace Api_farmacias.Model
{
   
    public class Farmacia
    {

       
        public string? Nome {get;set;}
       
        public long NIF {get;set;}
        public string? Email{get;set;}
        
        public DateTime HoraDeabertura{get;set;}
  
        public DateTime HoraDeEncerramento{get;set;}
   

    }
}