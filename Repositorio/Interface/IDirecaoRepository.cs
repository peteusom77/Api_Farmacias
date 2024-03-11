using Api_Farmacias.Model;
namespace Api_Farmacias.Repositorio.Interface
{
    public interface IDirecaoRepository
    {
        Task<Direcao> BuscarDirecaoPorId(int id);
        Task<List<DirecaoDTO>> direcoes(int id_farm);
        Task<Direcao> AdicionarDirecao(DirecaoDTO direcao);
        Task<Direcao> AtualizarDirecao(DirecaoDTO direcao,int id);
        public Task<bool> Apagardirecao(int id);
    }
}