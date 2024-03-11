using Api_Farmacias.Model;

namespace Api_Farmacias.Repositorio.Interface
{
    public interface ILocalizacaoRepository
    {
        Task<Localizacao> AdicionarLocali(LocalizacaoDTO localizacao);
        Task<Localizacao> AtualizarLocal(LocalizacaoDTO localizacao,int id);
        Task<Localizacao> BuscarLocalPorId(int id);
        Task<bool> ApagarLocal(int id);
    }
}