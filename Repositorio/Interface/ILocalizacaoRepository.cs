using Api_Farmacias.Model;

namespace Api_Farmacias.Repositorio.Interface
{
    public interface ILocalizacaoRepository
    {
        Task<Localizacao> AdicionarLocali(LocalizacaoDTO localizacao);
        Task<Localizacao> Atualizar(LocalizacaoDTO localizacao,int id);
        Task<Farmacia> BuscarLocalPorId(int id);
        
    }
}