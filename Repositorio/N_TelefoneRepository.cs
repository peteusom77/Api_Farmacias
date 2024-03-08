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
        public async Task<Farmacia> BuscarN_telefone(int Num)
        {
            var numT = await _conexao.farmacias.FirstOrDefaultAsync(f =>f.Id == Num);
            return numT;
        }
        public async Task<N_telefone> AdicionarN_telefone(N_telefoneDTO n_Telefone)
        {
            var fm = _mapper.Map<N_telefone>(n_Telefone);
            await _conexao.AddAsync(fm);
            await _conexao.SaveChangesAsync();
            return fm;
        }

        public Task<N_telefone> AtualizarN_telefone(N_telefoneDTO n_Telefone, int id)
        {
            throw new NotImplementedException();
        }
    }
}