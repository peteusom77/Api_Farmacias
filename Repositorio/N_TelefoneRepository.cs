using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api_Farmacias.DTO;
using Api_Farmacias.Model;
using Api_Farmacias.Repositorio.Interface;

namespace Api_Farmacias.Repositorio
{
    public class N_TelefoneRepository : IN_TelefoneRepository
    {
        public async Task<Farmacia> BuscarN_telefone(int id_farm)
        {
            var num = await _conexao.farmacias.FirstOrDefaultAsync(f.Id == id_farm);
            return num;
        }
        public Task<N_telefone> AdicionarN_telefone(N_telefoneDTO n_Telefone)
        {
            var fm = _mapper.Map<N_telefone>(n_Telefone);
            await _conexao.AddAsync(fm);
            await _conexao.SaveChangesAsync();
            return fm;
        }

        public Task<N_telefone> AtualizarN_telefone(N_telefone n_Telefone, int id)
        {
            throw new NotImplementedException();
        }
    }
}