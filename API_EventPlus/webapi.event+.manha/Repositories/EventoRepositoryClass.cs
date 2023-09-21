using webapi.event_.manha.Contexts;
using webapi.event_.manha.Domains;
using webapi.event_.manha.Interfaces;

namespace webapi.event_.manha.Repositories
{
    public class EventoRepositoryClass : IEventoRepository
    {

        private readonly EventContext _eventContext;

        public EventoRepositoryClass()
        {
            _eventContext = new EventContext();
        }

        public void Atualizar(Guid id, Evento evento)
        {
            throw new NotImplementedException();
        }

        public Evento BuscarPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(Evento evento)
        {
            _eventContext.Evento.Add(evento);
            _eventContext.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            Evento evento = _eventContext.Evento.Find(id)!;
            _eventContext.Evento.Remove(evento);
            _eventContext.SaveChanges();
        }

        public List<Evento> Listar()
        {
            throw new NotImplementedException();
        }
    }
}
