using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api_Farmacias.Model;

namespace Api_Farmacias.Repositorio.Interface
{
    public interface IN_TelefoneRepository
    {
        Task<N_telefone> AdicionarN_telefone(N_telefone n_Telefone);
        Task<N_telefone> AtualizarN_telefone(N_telefone n_Telefone,int id);
    }
}