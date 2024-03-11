using Api_Farmacias.Database;
using Api_Farmacias.DTO;
using Api_Farmacias.Model;
using Api_Farmacias.Repositorio.Interface;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Api_Farmacias.Repositorio
{
    public class N_TelefoneRepository : IN_TelefoneRepository
    {
        private readonly Appdbcontext _conexao;
        private readonly IMapper _mapper;

        public N_TelefoneRepository(Appdbcontext appdbcontext,IMapper mapper)
        {
            _conexao =appdbcontext;
            _mapper= mapper;
        }
        public async Task<N_telefone> BuscarN_telefone(int Num)
        {
            var numT = await _conexao.n_Telefones.FirstOrDefaultAsync(f =>f.Id == Num);
            return numT;
        }
        public async Task<N_telefone> AdicionarN_telefone(N_telefoneDTO n_Telefone)
        {
            var fm = _mapper.Map<N_telefone>(n_Telefone);
            await _conexao.AddAsync(fm);
            await _conexao.SaveChangesAsync();
            return fm;
    
        }

        public async Task<N_telefone> AtualizarN_telefone(N_telefoneDTO n_Telefone, int id)
        {
             var n_teleid = BuscarN_telefone(id);
              if(n_teleid == null)
                {
                    throw new Exception($"O id:{id} não existe.");
                }
                var n_teleDto=_mapper.Map<N_telefone>(n_teleid);
                _conexao.n_Telefones.Update(n_teleDto);
                await _conexao.SaveChangesAsync();
                return n_teleDto;
        }
        public async Task<List<N_telefoneDTO>> telefones(int id_farm)
        {
            var lo =await _conexao.n_Telefones.Where(x=>x.farmacia_id == id_farm).ToListAsync();
            var ll =  _mapper.Map<List<N_telefoneDTO>>(lo);
            return ll;
        }

        public async Task<bool> Apagar(int id)
        {
            var telele = await BuscarN_telefone(id);
            if(telele == null)
            {
                throw new Exception($"O id:{id} não existe.");
            }
            var telelelDto =_mapper.Map<N_telefone>(telele);
            _conexao.n_Telefones.Remove(telelelDto);
            await _conexao.SaveChangesAsync();

        return true;
        }
    }
}