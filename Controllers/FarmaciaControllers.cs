using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api_farmacias.Model;
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
        [HttpPost]
        [Route("adicionar")]
        public async Task<ActionResult<Farmacia>>Adicionarfarm([FromBody] Farmacia farmacia)
        {
            return Ok(await _farmfonte.SaveAllAsync());
        }
    }
}