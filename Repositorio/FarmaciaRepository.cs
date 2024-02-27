using Api_farmacias.Model;
using Api_Farmancias.Repositorio.InterFace;


namespace Api_Farmancias.Repositorio
{
    public class FarmaciaRepository : IFarmaciaRepisitory
    {
        public Task<Farmacia> Adicionar(Farmacia farmancia)
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
    }
}