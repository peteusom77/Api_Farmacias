using Api_Farmacias.Model;
using Microsoft.EntityFrameworkCore;
namespace Api_Farmacias.Database
{
    public class Appdbcontext:DbContext
    {
        
        public DbSet<Farmacia> farmacias{get;set;}
        public DbSet<Localizacao> localizacaos{get;set;}
        public DbSet<N_telefone> n_Telefones{get;set;}
        public DbSet<Direcao> direcaos{get;set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //sua palavra password essa n é a minha kkkk
<<<<<<< HEAD
            optionsBuilder.UseNpgsql(connectionString:"Host=localhost;Username=postgres;password=;database=Farmacias");
=======
            optionsBuilder.UseNpgsql(connectionString:"Host=localhost;Username=postgres;password=1234;database=Farmacias");
>>>>>>> e8c4fd805e93ed5adf13aafb1b18d9af2134649b
        }

       
    }
}
