using Api_Farmacias.Model;
namespace Api_Farmacias.Repositorio.Interface
{
    public interface IDirecaoRepository
    {
        Task<Farmacia> BuscarDirecaoPorId(int id);
        Task<Direcao> AdicionarDirecao(DirecaoDTO direcao);
        Task<Direcao> AtualizarDirecao(DirecaoDTO direcao,int id);
        public Task<bool> Apagardirecao(int id);
    }
}