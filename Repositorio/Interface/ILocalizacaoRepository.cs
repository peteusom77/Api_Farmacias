using Api_Farmacias.Model;

namespace Api_Farmacias.Repositorio.Interface
{
    public interface ILocalizacaoRepository
    {
        Task<Localizacao> AdicionarLocali(LocalizacaoDTO localizacao);
        Task<List<LocalizacaoDTO>> localzacoes(int farm_id);
        Task<Localizacao> AtualizarLocal(LocalizacaoDTO localizacao,int id);
        Task<Localizacao> BuscarLocalPorId(int id);
        Task<Localizacao> Buscar(int id);
        Task<bool> ApagarLocal(int id);
        public Task<bool> Apagar(int id);
    }
}