using Api_Farmacias.Model;
namespace Api_Farmacias.Repositorio.Interface
{
    public interface IDirecaoRepository
    {
        Task<Direcao> BuscarDirecaoPorId(int id);
<<<<<<< HEAD
        Task<List<DirecaoDTO>> direcoes(int id_farm);
=======
>>>>>>> e8c4fd805e93ed5adf13aafb1b18d9af2134649b
        Task<Direcao> AdicionarDirecao(DirecaoDTO direcao);
        Task<Direcao> AtualizarDirecao(DirecaoDTO direcao,int id);
        public Task<bool> Apagardirecao(int id);
    }
}