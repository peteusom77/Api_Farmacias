using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api_farmacias.Model;
using Api_farmancias.Model;

namespace Api_Farmacias.Repositorio.Interface
{
    public interface IDirecaoRepository
    {
        Task<Direcao> AdicionsrDirecao(Direcao direcao);
        Task<Direcao> AtualizarDirecao(Direcao direcao,int id);
    }
}