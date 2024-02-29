using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api_Farmancias.Model;

namespace Api_Farmacias.Repositorio.Interface
{
    public interface IDirecaoRepository
    {
        Task<Direcao> AdicionsrDirecao(Direcao direcao);
        Task<Direcao> AtualizarDirecao(Direcao direcao,int id);
    }
}