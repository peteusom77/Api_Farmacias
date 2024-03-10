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
            Direcao direcao = await _direcao.AdicionsrDirecao(todos.direcaoDTO);
            //
            todos.n_TelefoneDTO.farmacia_id =farmacias.Id;
            N_telefone n_Telefone = await _ntele.AdicionarN_telefone(todos.n_TelefoneDTO);
            //
            return Ok(new { Farmacia = farmacias, Localizacao = localizacao,  N_Telefone = n_Telefone});
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

        [HttpPut("AtualizarLocalizacao{id}")]
        public async Task<ActionResult<Localizacao>> AtualizarLocate([FromBody] LocalizacaoDTO localizacao, int id)
        {
            localizacao.farmacia_id = id;
            var locate = await _locali.Atualizar(localizacao, id);
            return Ok(locate);
        }

        [HttpPut("AtualizarDirecao{id}")]
        public async Task<ActionResult<Direcao>> AtualizarDirecao([FromBody] DirecaoDTO direcao, int id)
        {
            direcao.farmacia_id = id;
            var direct = await _direcao.AtualizarDirecao(direcao, id);
            return Ok(direct);
        }

        [HttpPut("AtualizarTelefone{id}")]
        public async Task<ActionResult<N_telefone>> AtualizarTelefone([FromBody] N_telefoneDTO n_Telefone, int id)
        {
            n_Telefone.farmacia_id = id;
            var telele = await _ntele.AtualizarN_telefone(n_Telefone, id);
            return Ok(telele);
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
    }
}