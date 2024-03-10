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
        public async Task<Farmacia> BuscarLocalPorId(int id_farm)
        {
            var lo = await _conexao.farmacias.FirstOrDefaultAsync(f => f.Id == id_farm);
            return lo;
        }
        public async Task<Localizacao> AdicionarLocali(LocalizacaoDTO localizacao)
        {
            var farm = _mapper.Map<Localizacao>(localizacao);
            await _conexao.AddAsync(farm);
            await _conexao.SaveChangesAsync();
            return farm;
        }

        public Task<Localizacao> Atualizar(LocalizacaoDTO localizacao, int id)
        {
            throw new NotImplementedException();
        }
    }
}