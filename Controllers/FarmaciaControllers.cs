using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api_Farmacias.Model;
using Api_Farmancias.Repositorio.InterFace;
using Microsoft.AspNetCore.Mvc;

namespace Api_Farmacias.Controllers
{
    [ApiController]
    [Route("Api/[controller]")]
    public class FarmaciaControllers:ControllerBase
    {
        protected readonly IFarmaciaRepisitory _farmfonte;
        public FarmaciaControllers(IFarmaciaRepisitory farmfonte)
        {
            _farmfonte=farmfonte;
        }

        [HttpGet]
        public async Task<ActionResult<List<Farmacia>>> BuscartodasFarmacia()
        {
            List<Farmacia> farmacias = await _farmfonte.Farmancias();
            return Ok(farmacias);
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<Farmacia>> Buscarfarmacia(int id)
        {
            Farmacia farmacias = await _farmfonte.BuscarFarmacia(id);
            return Ok(farmacias);
        }

        [HttpPost]
        [Route("adicionarFarmacia")]
        public async Task<ActionResult<Farmacia>>Adicionarfarm([FromBody] Todos todos)
        {
            Farmacia farmacias = await _farmfonte.AdicionarFarmacia(todos.farmaciaDTO);
            todos.localizacaoDTO.farmacia_id = farmacias.Id;
            Localizacao localizacao = await _locali.AdicionarLocali(todos.localizacaoDTO);
            return Ok(new { Farmacia = farmacias, Localizacao = localizacao });
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

        [HttpPut("{id}")]
        public async Task<ActionResult<Farmacia>> Atualiza([FromBody] Farmacia farmacia1, int id)
        {
            farmacia1.Id = id;
            Farmacia farmacia = await _farmfonte.Atualizar(farmacia1, id);
            return Ok(farmacia);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Farmacia>> Deletar(int id)
        {
            bool apagado = await _farmfonte.Apagar(id);
            return Ok(apagado); 
        }
    }
}