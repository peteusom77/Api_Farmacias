using Api_Farmacias.Model;

namespace Api_Farmacias.Repositorio.Interface
{
    public interface ILocalizacaoRepository
    {
        Task<Localizacao> AdicionarLocali(LocalizacaoDTO localizacao);
        Task<List<LocalizacaoDTO>> localzacoes(int farm_id);
        Task <Localizacao> Atualizar(Localizacao localizacao,int id);
        
    }
}