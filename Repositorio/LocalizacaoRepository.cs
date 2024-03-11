using Api_Farmacias.Model;
using Api_Farmacias.Repositorio.Interface;
using Api_Farmacias.Database;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Api_Farmacias.Repositorio
{
    public class LocalizacaoRepository : ILocalizacaoRepository
    {
        private readonly Appdbcontext _conexao;
        private readonly IMapper _mapper;
        public LocalizacaoRepository(Appdbcontext appdbcontext, IMapper mapper)
        {
            _conexao =appdbcontext;
            _mapper =mapper;
        }
      
        public async Task<Localizacao> AdicionarLocali(LocalizacaoDTO localizacao)
        {
            var farm = _mapper.Map<Localizacao>(localizacao);
            await _conexao.AddAsync(farm);
            await _conexao.SaveChangesAsync();
            return farm;
        }

        public async Task<Localizacao> Atualizar(LocalizacaoDTO Listlocalizacao, int farm_id)
        {
            
        }

        public Task Atualizar(Localizacao localizacao, int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<LocalizacaoDTO>> localzacoes(int farm_id)
        {
            var lo = await _conexao.localizacaos.Where(x=>x.farmacia_id == farm_id).ToListAsync();
            var loDTO = _mapper.Map<List<LocalizacaoDTO>>(lo);
            return loDTO;
        }
    }
}