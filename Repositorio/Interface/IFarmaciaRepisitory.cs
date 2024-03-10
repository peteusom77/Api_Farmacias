using Api_Farmacias.Model;
namespace Api_Farmacias.Repositorio.InterFace
{
    public interface IFarmaciaRepisitory
    {
         Task<List<FarmaciaDTO>> Farmacias();
         Task<FarmaciaDTO> BuscarFarmacia(int id);
        Task<Farmacia> AdicionarFarmacia(FarmaciaDTO farmancia);
        Task <Farmacia> Atualizar(FarmaciaDTO farmancia, int id);
        Task<bool> Apagar(int id);

    }
}