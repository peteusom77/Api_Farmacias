using Api_Farmacias.Model;

namespace Api_Farmacias.Repositorio.Interface
{
    public interface ILocalizacaoRepository
    {
        Task<Localizacao> AdicionarLocali(LocalizacaoDTO localizacao);
        Task<Localizacao> Atualizar(Localizacao localizacao,int id);
        Task<Farmacia> BuscarLocalPorId(int id);
        
    }
}