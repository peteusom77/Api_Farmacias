using Api_Farmacias.Model;
namespace Api_Farmacias.Repositorio.Interface
{
    public interface IDirecaoRepository
    {
        Task<Direcao> AdicionsrDirecao(Direcao direcao);
        Task<Direcao> AtualizarDirecao(Direcao direcao,int id);
    }
}