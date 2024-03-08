using Api_Farmacias.DTO;
using Api_Farmacias.Model;

namespace Api_Farmacias.Repositorio.Interface
{
    public interface IN_TelefoneRepository
    {
        Task<Farmacia> BuscarN_telefone(int id_farm);
        Task<N_telefone> AdicionarN_telefone(N_telefoneDTO n_Telefone);
        Task<N_telefone> AtualizarN_telefone(N_telefoneDTO n_Telefone, int id);
    }
}