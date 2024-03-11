using Api_Farmacias.Model;

namespace Api_Farmacias.Repositorio.Interface
{
    public interface ILocalizacaoRepository
    {
        Task<Localizacao> AdicionarLocali(LocalizacaoDTO localizacao);
<<<<<<< HEAD
        Task<List<LocalizacaoDTO>> localzacoes(int farm_id);
        Task<Localizacao> AtualizarLocal(Localizacao localizacao,int id);
=======
        Task<Localizacao> AtualizarLocal(LocalizacaoDTO localizacao,int id);
>>>>>>> e8c4fd805e93ed5adf13aafb1b18d9af2134649b
        Task<Localizacao> BuscarLocalPorId(int id);
        Task<bool> ApagarLocal(int id);
    }
}