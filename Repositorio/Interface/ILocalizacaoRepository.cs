using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api_Farmacias.Model;
using Api_Farmancias.Model;

namespace Api_Farmacias.Repositorio.Interface
{
    public interface ILocalizacaoRepository
    {
        Task<Localizacao> AdicionarLocali(LocalizacaoDTO localizacao);
        Task<Localizacao> Atualizar(Localizacao localizacao,int id);
        Task<Farmacia> BuscarLocalPorId(int id);
        
    }
}