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
        [HttpPost]
        [Route("adicionarFarmacia")]
        public async Task<ActionResult<Farmacia>>Adicionarfarm([FromBody] Todos todos)
        {
            Farmacia farmacias = await _farmfonte.AdicionarFarmacia(todos.farmaciaDTO);
            //
            todos.localizacaoDTO.farmacia_id = farmacias.Id;//para o atributo id farmacia receber o id fda farmacia criada
            Localizacao localizacao = await _locali.AdicionarLocali(todos.localizacaoDTO);
            //
            todos.direcaoDTO.farmacia_id=farmacias.Id;
            Direcao direcao = await _direcao.AdicionarDirecao(todos.direcaoDTO);
            //
            todos.n_TelefoneDTO.farmacia_id =farmacias.Id;
            N_telefone n_Telefone = await _ntele.AdicionarN_telefone(todos.n_TelefoneDTO);
            //
            return Ok(new { Farmacia = farmacias, Localizacao = localizacao,  N_Telefone = n_Telefone, Direcao = direcao});
        }
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
        [HttpPut("AtualizarFarmacia{id:int}")]
        public async Task<ActionResult<Farmacia>> Atualiza([FromBody] FarmaciaDTO farmacia1, int id)
        {
            farmacia1.Id = id; 
            var farmacia = await _farmfonte.Atualizar(farmacia1, id);
            return Ok(farmacia);
        }
///////////////////////////////////////////////////////////////////////////////////////////////////////////////
////////AndPoinst do tipo Get ⬇️
        [HttpGet("ListarFarmacias")]
        public async Task<ActionResult<List<Farmacia>>> BuscartodasFarmacia()
        {
            List<FarmaciaDTO> farmacias = await _farmfonte.Farmacias();
            return Ok(farmacias);
        }
        
        [HttpGet("BuscarFarmacia{id}")]
        public async Task<ActionResult<FarmaciaDTO>> Buscarfarmacia(int id)
        {
            FarmaciaDTO farmacias = await _farmfonte.BuscarFarmacia(id);
            return Ok(farmacias);
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////
////////AndPoinst do tipo Delete ⬇️
        [HttpDelete("ApagarFarmacia{id}")]
        public async Task<ActionResult> ApagarFarmacia(int id)
        {
            await _farmfonte.Apagar(id);
            await _direcao.Apagardirecao(id);
            await _locali.ApagarLocal(id);
            await _ntele.Apagartelele(id);
            return Ok();
        }
    }
}