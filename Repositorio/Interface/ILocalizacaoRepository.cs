using Api_Farmacias.Model;

namespace Api_Farmacias.Repositorio.Interface
{
    public interface ILocalizacaoRepository
    {
        Task<Localizacao> AdicionarLocali(LocalizacaoDTO localizacao);
<<<<<<< HEAD
        Task<Localizacao> AtualizarLocal(Localizacao localizacao,int id);
        Task<LocalizacaoDTO> BuscarLocalPorId(int id);
        Task<bool> ApagarLocal(int id);
=======
        Task<Localizacao> Atualizar(LocalizacaoDTO localizacao,int id);
        Task<Farmacia> BuscarLocalPorId(int id);
>>>>>>> c6c3be87503ea9928465a729cc0faf8cbcab921d
        
    }
}