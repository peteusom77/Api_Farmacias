using Api_Farmacias.Database;
using Api_Farmacias.Model;
using Api_Farmacias.Repositorio.Interface;
namespace Api_Farmacias.Repositorio
{
    public class DirecaoRepository : IDirecaoRepository
    {
        protected readonly Appdbcontext _dbcontext;
        public DirecaoRepository(Appdbcontext appdbcontext)
        {
            _dbcontext = appdbcontext;
        }
        public Task<Direcao> AdicionsrDirecao(Direcao direcao)
        {
            throw new NotImplementedException();
        }

        public Task<Direcao> AtualizarDirecao(Direcao direcao, int id)
        {
            throw new NotImplementedException();
        }
    }
}