using Api_Farmacias.Database;
using Api_Farmacias.Model;
using Api_Farmacias.Repositorio.InterFace;
using AutoMapper;
using Microsoft.EntityFrameworkCore;


namespace Api_Farmancias.Repositorio
{
    public class FarmaciaRepository : IFarmaciaRepository
    {
        private readonly Appdbcontext _conexao;
        private readonly IMapper _mapper;


        public FarmaciaRepository(Appdbcontext conexaoDB,IMapper mapper)
        {
            _conexao = conexaoDB;
            _mapper= mapper;

        }

       public async Task<List<FarmaciaDTO>> Farmacias()
        {
            var ListFArm = await _conexao.farmacias.ToListAsync();
            var farmDTO =_mapper.Map<List<FarmaciaDTO>>(ListFArm);
            return farmDTO;
        }
        public async Task<Farmacia> BuscarFarmacia(int id)
        {
            var farmacia = await _conexao.farmacias.Where(x => x.Id == id).FirstOrDefaultAsync();
            var farmDTO = _mapper.Map<Farmacia>(farmacia);
            return farmDTO ;
        }

        public async Task<Farmacia> AdicionarFarmacia(FarmaciaDTO farmacia)
        {
            var farmDTO =_mapper.Map<Farmacia>(farmacia);
            await _conexao.farmacias.AddAsync(farmDTO);
            await _conexao.SaveChangesAsync();
            return farmDTO;
        }

       public async Task<FarmaciaDTO> Atualizar(FarmaciaDTO farmacia, int id)
        {
            var farmaciaid = await BuscarFarmacia(id);
            if(farmaciaid == null)
            {
                throw new Exception($"Farmacia para o ID:{id} nao encontrado.");
            }
            farmaciaid.Nome = farmacia.Nome;
            farmaciaid.NIF = farmacia.NIF;
            farmaciaid.Email = farmacia.Email;
            farmaciaid.HoraDeabertura = farmacia.HoraDeabertura;
            farmaciaid.HoraDeEncerramento = farmacia.HoraDeEncerramento;
            var farmDTO = _mapper.Map<Farmacia>(farmaciaid);
            _conexao.farmacias.Update(farmDTO);
            await _conexao.SaveChangesAsync();

            return farmacia;
        }

        public async Task<bool> Apagar(int id)
        {
            Farmacia farmaciaid = await BuscarFarmacia(id);
            if(farmaciaid == null)
            {
                throw new Exception($"Farmacia para o ID:{id} nao encontrado.");
            }
            _conexao.farmacias.Remove(farmaciaid);
            await _conexao.SaveChangesAsync();
            return true;
        }

    }
}