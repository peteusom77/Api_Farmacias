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
        [Route("adicionar")]
        public async Task<ActionResult<Farmacia>>Adicionarfarm([FromBody] Farmacia farmacia)
        {
            Farmacia farmacias = await _farmfonte.AdicionarFarmacia(farmacia);
            return Ok(farmacias);
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