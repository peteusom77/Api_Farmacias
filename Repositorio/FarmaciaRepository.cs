using Api_farmacias.Model;
using Api_Farmacias.Model;
using Api_Farmancias.DAL.Database;
using Api_Farmancias.Repositorio.InterFace;
using Microsoft.EntityFrameworkCore;


namespace Api_Farmancias.Repositorio
{
    public class FarmaciaRepository : IFarmaciaRepisitory
    {
        protected readonly Appdbcontext _dbcontext;
        public FarmaciaRepository(Appdbcontext appdbcontext)
        {
            _dbcontext =appdbcontext;
        }

        public Task<Farmacia> AdicionarFarmacia(Farmacia farmancia)
        {
           throw new NotImplementedException();
        }

        public Task<bool> Apagar(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Farmacia> Atualizar(Farmacia farmancia)
        {
            throw new NotImplementedException();
        }

        public Task<Farmacia> BuscarFarmacia(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Farmacia>> Farmancias()
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}