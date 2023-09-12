using Microsoft.EntityFrameworkCore;
using webapi.inlock.dbFirst.Contexts;
using webapi.inlock.dbFirst.Domains;
using webapi.inlock.dbFirst.Interfaces;

namespace webapi.inlock.dbFirst.Repositories
{
    public class EstudioRepository : IEstudioRepository
    {
        //instancia de uma classe do tipo InlockContext
        InlockContext ctx = new InlockContext();
        public void Atualizar(Guid id, Estudio estudio)
        {
            throw new NotImplementedException();
        }

        public Estudio BuscarPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(Estudio novoEstudio)
        {
            throw new NotImplementedException();
        }

        public void Deletar(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<Estudio> Listar()
        {
            //Chamaro objeto ctx para executar o metodo de listagem nativo do context dentro do banco de dados
            return ctx.Estudios.ToList();
        }

        public List<Estudio> ListarComJogos()
        {
            return ctx.Estudios.Include(e => e.Jogos).ToList();
        }
    }
}
