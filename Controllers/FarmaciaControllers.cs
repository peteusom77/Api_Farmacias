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
        [HttpPost("Adicionardirecao/{id_farm}")]
        public async Task<ActionResult<Localizacao>> Adicionardirecao([FromBody] DirecaoDTO dire, int id_farm)
        {
            try
            {
                var farmacia = await _farmfonte.BuscarFarmacia(id_farm);
                if (farmacia == null)
                {
                    return NotFound($"Farmácia com ID {id_farm} não encontrada.");
                }
                dire.farmacia_id = farmacia.Id;
                var direcaoo = await _direcao.AdicionarDirecao(dire);
                return Ok(direcaoo);
            }
            catch (Exception ex)
            {
                // Lide com a exceção de maneira apropriada, log ou retorne um erro HTTP 500, se necessário.
                return StatusCode(500, $"Erro ao adicionar localização: {ex.Message}");
            }
        }
        [HttpPost("AdicionarN_telefone/{id_farm}")]
        public async Task<ActionResult<Localizacao>> AdicionarN_telefone([FromBody] N_telefoneDTO nume, int id_farm)
        {
            try
            {
                var farmacia = await _farmfonte.BuscarFarmacia(id_farm);
                if (farmacia == null)
                {
                    return NotFound($"Farmácia com ID {id_farm} não encontrada.");
                }
                nume.farmacia_id = farmacia.Id;
                var n_Telefone = await _ntele.AdicionarN_telefone(nume);
                return Ok(n_Telefone);
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
            List<DirecaoDTO> direcaoDTOs = await _direcao.direcoes(id);
            List<N_telefoneDTO> n_TelefoneDTOs = await _ntele.telefones(id);    
            return Ok(new{Farmacia =farmacias,Localizacao =localizacaos,Direcao =direcaoDTOs,N_telefone = n_TelefoneDTOs});
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