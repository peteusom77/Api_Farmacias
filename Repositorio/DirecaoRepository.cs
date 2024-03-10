using Api_Farmacias.Database;
using Api_Farmacias.Model;
using Api_Farmacias.Repositorio.Interface;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Api_Farmacias.Repositorio
{
    public class DirecaoRepository : IDirecaoRepository
    {
        private readonly Appdbcontext _conexao;
        private readonly IMapper _mapper;
        public DirecaoRepository(Appdbcontext appdbcontext, IMapper mapper)
        {
            _conexao = appdbcontext;
            _mapper= mapper;

        }
            public async Task<Farmacia> BuscarDirecaoPorId(int id)
            {
                var dir = await _conexao.farmacias.FirstOrDefaultAsync(f => f.Id == id);
                return dir;
            }
        
            public Task<Direcao> AdicionsrDirecao(DirecaoDTO direcao)
            {
                var farm = _mapper.Map<Direcao>(direcao);
                await _conexao.AddAsync(farm);
                await _conexao.SaveChangesAsync();
                return farm
            }

            public Task<Direcao> AtualizarDirecao(DirecaoDTO direcao,int id)
            {
                var farm = _mapper.Map<Direcao>(direcao);
                await _conexao.Update(farm);
                await _conexao.SaveChangesAsync();
                return farm;
            }
        
    }
}