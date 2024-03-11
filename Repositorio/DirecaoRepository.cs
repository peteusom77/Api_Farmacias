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
            public async Task<Direcao> BuscarDirecaoPorId(int id)
            {
                var direcao = await _conexao.direcaos.Where(x => x.farmacia_id == id).FirstOrDefaultAsync();
                var direcaoDTO = _mapper.Map<Direcao>(direcao);
                return direcaoDTO ;
            }
        
            public async Task<Direcao> AdicionarDirecao(DirecaoDTO direcao)
            {
                var farm = _mapper.Map<Direcao>(direcao);
                await _conexao.AddAsync(farm);
                await _conexao.SaveChangesAsync();
                return farm;
            }

            public async Task<Direcao> AtualizarDirecao(DirecaoDTO direcao,int id)
            {
                var direcaoid = BuscarDirecaoPorId(id);
                if(direcaoid == null)
                {
                    throw new Exception($"O id:{id} não existe.");
                }
                var direcaoDto=_mapper.Map<Direcao>(direcaoid);
                _conexao.direcaos.Update(direcaoDto);
                await _conexao.SaveChangesAsync();
                return direcaoDto;
            }
            public async Task<bool> Apagardirecao(int id)
            {
            Direcao direcaoid = await BuscarDirecaoPorId(id);
            if(direcaoid == null)
            {
                throw new Exception($"O id:{id} não existe.");
            }
            _conexao.direcaos.Remove(direcaoid);
            await _conexao.SaveChangesAsync();
            return true;
        }

        
    }
}