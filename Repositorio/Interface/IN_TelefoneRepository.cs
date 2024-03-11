using System.Security.Principal;
using Api_Farmacias.DTO;
using Api_Farmacias.Model;

namespace Api_Farmacias.Repositorio.Interface
{
    public interface IN_TelefoneRepository
    {
<<<<<<< HEAD
        Task<List<N_telefoneDTO>> telefones(int id_farm);
        Task<N_telefone> BuscarN_telefone(int id_farm);
        Task<N_telefone> AdicionarN_telefone(N_telefoneDTO n_Telefone);
        Task<N_telefone> AtualizarN_telefone(N_telefoneDTO n_Telefone, int id);
        Task<bool> Apagar(int id);
=======
        Task<N_telefone> BuscarN_telefone(int id_farm);
        Task<N_telefone> AdicionarN_telefone(N_telefoneDTO n_Telefone);
        Task<N_telefone> AtualizarN_telefone(N_telefoneDTO n_Telefone, int id);
        Task<bool> Apagartelele(int id);
>>>>>>> e8c4fd805e93ed5adf13aafb1b18d9af2134649b
    }
}