using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api_Farmacias.Repositorio.Interface;
using Api_Farmancias.Database;
using Api_Farmancias.Model;

namespace Api_Farmacias.Repositorio
{
    public class DirecaoRepository : IDirecaoRepository
    {
        protected readonly Appdbcontext _dbcontext;
        public DirecaoRepository(Appdbcontext appdbcontext)
        {
            _dbcontext = appdbcontext;
        }
        public Task<Direcao> AdicionsrDirecao(Direcao direcao)
        {
            throw new NotImplementedException();
        }

        public Task<Direcao> AtualizarDirecao(Direcao direcao, int id)
        {
            throw new NotImplementedException();
        }
    }
}