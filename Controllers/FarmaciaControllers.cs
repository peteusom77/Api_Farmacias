using Api_Farmacias.DTO;
using Api_Farmacias.Model;
using Api_Farmacias.Repositorio.Interface;
using Api_Farmacias.Repositorio.InterFace;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
namespace Api_Farmacias.Controllers
{
    [ApiController]
    [Route("Api/[controller]")]
    public class FarmaciaControllers:ControllerBase
    {
        protected readonly IFarmaciaRepository _farmfonte;
        protected readonly ILocalizacaoRepository _locali;
        protected readonly IDirecaoRepository _direcao;
        protected readonly IN_TelefoneRepository _ntele;
        //Injeção de dependecias
        public FarmaciaControllers(IFarmaciaRepository farmfonte,IMapper mapper,ILocalizacaoRepository localizacaoRepository,IDirecaoRepository direcaoRepository,IN_TelefoneRepository n_TelefoneRepository)
        {
            _farmfonte=farmfonte;
            _direcao =direcaoRepository;
            _locali =localizacaoRepository;
            _ntele = n_TelefoneRepository;
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////
////////AndPoinst do tipo Post ⬇️
        [HttpPost("AdicionarLocalizacao/{id_farm}")]
        public async Task<ActionResult<Localizacao>> AdicionarLocalizacao([FromBody] LocalizacaoDTO locali, int id_farm)
        {
            try
            {
                var farmacia = await _farmfonte.BuscarFarmacia(id_farm);
                if (farmacia == null)
                {
                    return NotFound($"Farmácia com ID {id_farm} não encontrada.");
                }
                locali.farmacia_id = farmacia.Id;
                var localizacao = await _locali.AdicionarLocali(locali);
                return Ok(localizacao);
            }
            catch (Exception ex)
            {
                // Lide com a exceção de maneira apropriada, log ou retorne um erro HTTP 500, se necessário.
                return StatusCode(500, $"Erro ao adicionar localização: {ex.Message}");
            }
        }
///////////////////////////////////////////////////////////////////////////////////////////////////////////////
////////AndPoinst do tipo Put ⬇️

///////////////////////////////////////////////////////////////////////////////////////////////////////////////
////////AndPoinst do tipo Get ⬇️
        [HttpGet("ListarFarmacias")]
        public async Task<ActionResult<List<Todos_Get>>> BuscartodasFarmacia()
        {
            List<FarmaciaDTO> farmaciaDTOs = await _farmfonte.Farmacias();
            List<Todos_Get> todos_GetsLIST= new List<Todos_Get>();
            foreach (var farmacia in farmaciaDTOs)
            {
                List<LocalizacaoDTO> localizacaos =await _locali.localzacoes(farmacia.Id);
                List<DirecaoDTO> direcaoDTOs = await _direcao.direcoes(farmacia.Id);
                List<N_telefoneDTO> n_TelefoneDTOs = await _ntele.telefones(farmacia.Id);
                todos_GetsLIST.Add(new Todos_Get {
                    NN_TelefoneDTOs =n_TelefoneDTOs,
                    FFarmaciaDTO =farmacia,
                    LLocalizacaos =localizacaos,
                    DDirecaoDTOs =direcaoDTOs
                });
            
            }
            return Ok(todos_GetsLIST);
            
        }
        
        [HttpGet("BuscarFarmacia{id}")]
        public async Task<ActionResult<object>> Buscarfarmacia(int id)
        {
            Farmacia farmacias = await _farmfonte.BuscarFarmacia(id);
            if(farmacias ==null)
            {
                return NotFound();
            }
            List<LocalizacaoDTO> localizacaos= await _locali.localzacoes(id);            
            return Ok(new{Farmacia =farmacias,Localizacao =localizacaos});
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////
////////AndPoinst do tipo Delete ⬇️
        [HttpDelete("ApagarFarmacia{id}")]
        public async Task<ActionResult> ApagarFarmacia(int id)
        {
            await _locali.ApagarLocal(id);
            await _direcao.Apagardirecao(id);
            await _ntele.Apagar(id);
            await _farmfonte.Apagar(id);
            return Ok();
        }
    }
}