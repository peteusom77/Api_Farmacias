using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api_farmacias.Model;
using Microsoft.EntityFrameworkCore;

namespace Api_Farmancias.DAL.Database
{
    public class Appdbcontext:DbContext
    {
        public DbSet<Farmacia>farmancias{get;set;}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //sua palavra password essa n é a minha kkkk
            optionsBuilder.UseNpgsql(connectionString:"Host=localhost;Username=postgres;password=1234567;database=Farmacia");
        }
    }
}