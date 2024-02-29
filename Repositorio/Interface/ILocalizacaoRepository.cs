using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api_farmacias.Model;
using Api_farmancias.Model;

namespace Api_Farmacias.Repositorio.Interface
{
    public interface ILocalizacaoRepository
    {
        Task<Localizacao> AdicionarLocali(Localizacao localizacao);
        Task<Localizacao> Atualizar(Localizacao localizacao,int id);
        Task<Farmacia> BuscarEmailPorId(int id);
    }
}