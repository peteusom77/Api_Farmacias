using Api_Farmacias.Model;
namespace Api_Farmacias.Repositorio.InterFace
{
    public interface IFarmaciaRepository
    {
         Task<List<FarmaciaDTO>> Farmacias();
         Task<Farmacia> BuscarFarmacia(int id);
        Task<Farmacia> AdicionarFarmacia(FarmaciaDTO farmancia);
        Task <Farmacia> Atualizar(FarmaciaDTO farmancia, int id);
        Task<bool> Apagar(int id);

    }
}