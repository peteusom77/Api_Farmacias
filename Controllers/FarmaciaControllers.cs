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
////////AndPoinst do tipo Delete ⬇️
        [HttpDelete("ApagarFarmacia{id}")]
        public async Task<ActionResult> ApagarFarmacia(int id)
        {
            await _locali.ApagarLocal(id);
            await _direcao.Apagardirecao(id);
            await _ntele.Apagartelele(id);
            await _farmfonte.Apagar(id);
            return Ok();
        }
    }
}