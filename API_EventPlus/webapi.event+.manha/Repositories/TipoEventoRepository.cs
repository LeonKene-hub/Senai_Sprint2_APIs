using webapi.event_.manha.Contexts;
using webapi.event_.manha.Domains;
using webapi.event_.manha.Interfaces;

namespace webapi.event_.manha.Repositories
{
    public class TipoEventoRepository : ITipoEventoRepository
    {
        private readonly EventContext ctx;

        public TipoEventoRepository()
        {
            ctx = new EventContext();
        }

        public void Atualizar(Guid id, TiposEvento tipo)
        {
            TiposEvento tipoBuscado = ctx.TiposEvento.Find(id)!;

            if (tipoBuscado != null)
            {
                tipoBuscado.Titulo = tipo.Titulo;
            }
            ctx.Update(tipoBuscado);
            ctx.SaveChanges();
        }

        public TiposEvento BuscarPorId(Guid id)
        {
            return ctx.TiposEvento.FirstOrDefault(t => t.IdTipoEvento == id)!;
        }

        public void Cadastrar(TiposEvento tipoEvento)
        {
            ctx.TiposEvento.Add(tipoEvento);
            ctx.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            TiposEvento tipoEvento = ctx.TiposEvento.FirstOrDefault(t => t.IdTipoEvento ==id)!;
            ctx.TiposEvento.Remove(tipoEvento);
            ctx.SaveChanges();
        }

        public List<TiposEvento> Listar()
        {
            return ctx.TiposEvento.ToList();
        }
    }
}
