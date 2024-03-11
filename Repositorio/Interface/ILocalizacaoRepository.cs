using Api_Farmacias.Model;

namespace Api_Farmacias.Repositorio.Interface
{
    public interface ILocalizacaoRepository
    {
        Task<Localizacao> AdicionarLocali(LocalizacaoDTO localizacao);
        Task<Localizacao> AtualizarLocal(Localizacao localizacao,int id);
        Task<LocalizacaoDTO> BuscarLocalPorId(int id);
        Task<bool> ApagarLocal(int id);
        
    }
}