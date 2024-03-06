using Api_Farmacias.Model;
namespace Api_Farmancias.Repositorio.InterFace
{
    public interface IFarmaciaRepisitory
    {
         Task<List<FarmaciaDTO>> Farmancias();
         Task<FarmaciaDTO> BuscarFarmacia(int id);
        Task<Farmacia> AdicionarFarmacia(FarmaciaDTO farmancia);
        Task <Farmacia> Atualizar(FarmaciaDTO farmancia, int id);
        Task<bool> Apagar(int id);

    }
}