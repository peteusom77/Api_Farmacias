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

        public async Task<Localizacao> AtualizarLocal(Localizacao localizacao, int id)
        {
            var localid = BuscarLocalPorId(id);
              if(localid == null)
                {
                    throw new Exception($"O id:{id} não existe.");
                }
                var localDto=_mapper.Map<Localizacao>(localid);
                _conexao.localizacaos.Update(localDto);
                await _conexao.SaveChangesAsync();
                return localDto;
        }

        

        public async Task<bool> ApagarLocal(int id)
        {   var localid = BuscarLocalPorId(id);

            if(localid == null)
            {
                throw new Exception($"O id:{id} não existe.");
            }
          var localDto =_mapper.Map<Localizacao>(localid);
          _conexao.localizacaos.Remove(localDto);
          await _conexao.SaveChangesAsync();

        return true;

        }

        
    }
}