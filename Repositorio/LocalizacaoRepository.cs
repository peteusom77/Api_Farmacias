using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api_farmacias.Model;
using Api_Farmacias.Repositorio.Interface;
using Api_farmancias.Model;

namespace Api_Farmacias.Repositorio
{
    public class LocalizacaoRepository : ILocalizacaoRepository
    {
        public Task<Localizacao> AdicionarLocali(Localizacao localizacao)
        {
            throw new NotImplementedException();
        }

        public Task<Localizacao> Atualizar(Localizacao localizacao, int id)
        {
            throw new NotImplementedException();
        }

        public Task<Farmacia> BuscarEmailPorId(int id)
        {
            throw new NotImplementedException();
        }
    }
}