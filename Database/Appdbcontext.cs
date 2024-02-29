using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api_farmacias.Model;
using Api_Farmacias.Model;
using Api_farmancias.Model;
using Microsoft.EntityFrameworkCore;

namespace Api_Farmancias.DAL.Database
{
    public class Appdbcontext:DbContext
    {
        public DbSet<Farmacia> farmancias{get;set;}
        public DbSet<Localizacao> localizacaos{get;set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //sua palavra password essa n é a minha kkkk
            optionsBuilder.UseNpgsql(connectionString:"Host=localhost;Username=postgres;password=123456789;database=Farmacias");
        }
        

    }
}