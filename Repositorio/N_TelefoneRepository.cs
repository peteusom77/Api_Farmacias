using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api_Farmacias.Model;
using Api_Farmacias.Repositorio.Interface;

namespace Api_Farmacias.Repositorio
{
    public class N_TelefoneRepository : IN_TelefoneRepository
    {
        public Task<N_telefone> AdicionarN_telefone(N_telefone n_Telefone)
        {
            throw new NotImplementedException();
        }

        public Task<N_telefone> AtualizarN_telefone(N_telefone n_Telefone, int id)
        {
            throw new NotImplementedException();
        }
    }
}