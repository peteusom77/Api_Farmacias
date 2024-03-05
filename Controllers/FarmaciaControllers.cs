using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Api_Farmacias.Model;
using Api_Farmancias.Repositorio.InterFace;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Api_Farmacias.Controllers
{
    [ApiController]
    [Route("Api/[controller]")]
    public class FarmaciaControllers:ControllerBase
    {
        protected readonly IFarmaciaRepisitory _farmfonte;
        private readonly IMapper _mapper;
        public FarmaciaControllers(IFarmaciaRepisitory farmfonte,IMapper mapper)
        {
            _farmfonte=farmfonte;
            _mapper=mapper;
        }

        [HttpGet("ListarFarmacias")]
        public async Task<ActionResult<List<FarmaciaDTO>>> BuscartodasFarmacia()
        {
            List<FarmaciaDTO> farmacias = await _farmfonte.Farmancias();
            return Ok(farmacias);
        }
        
        [HttpGet("BuscarFarmacia{id}")]
        public async Task<ActionResult<FarmaciaDTO>> Buscarfarmacia(int id)
        {
            FarmaciaDTO farmacias = await _farmfonte.BuscarFarmacia(id);
            return Ok(farmacias);
        }

        [HttpPost]
        [Route("adicionarFarmacia")]
        public async Task<ActionResult<Farmacia>>Adicionarfarm([FromBody] FarmaciaDTO farmacia)
        {
            Farmacia farmacias = await _farmfonte.AdicionarFarmacia(farmacia);
            var options = new JsonSerializerOptions
    {
        ReferenceHandler = ReferenceHandler.Preserve
    };

    string json = JsonSerializer.Serialize(farmacias, options);

    return Ok(json);
        }

        [HttpPut("AtualizarFarmacia{id:int}")]
        public async Task<ActionResult<Farmacia>> Atualiza([FromBody] FarmaciaDTO farmacia1, int id)
        {
            farmacia1.Id = id; 
            var farmacia = await _farmfonte.Atualizar(farmacia1, id);
            return Ok(farmacia);
        }

    
    }
}