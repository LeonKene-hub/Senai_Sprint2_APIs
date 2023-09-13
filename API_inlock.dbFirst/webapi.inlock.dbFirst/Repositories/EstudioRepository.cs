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
            Estudio estudioBuscado = ctx.Estudios.Find(id)!;

            if (estudioBuscado != null)
            {
                estudioBuscado.Nome = estudio.Nome;
            }

            ctx.Estudios.Update(estudioBuscado!);
            ctx.SaveChanges();
        }

        public Estudio BuscarPorId(Guid id)
        {
            return ctx.Estudios.FirstOrDefault(e => e.IdEstudio == id)!;
        }

        public void Cadastrar(Estudio novoEstudio)
        {
            novoEstudio.IdEstudio = Guid.NewGuid();
            ctx.Estudios.Add(novoEstudio);
            ctx.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            Estudio estudioBuscado = ctx.Estudios.Find(id)!;
            ctx.Estudios.Remove(estudioBuscado);
            ctx.SaveChanges();
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
