using Trabalho_Final_ProgWebIII.Core.Interface;
using Trabalho_Final_ProgWebIII.Core.Model;

namespace Trabalho_Final_ProgWebIII.Core.Service
{
    public class EventoService: IEventoService
    {
        public IEventoRepository _eventoRepository;
        public EventoService(IEventoRepository eventoRepository)
        {
            _eventoRepository = eventoRepository;
        }

        public bool AlterarEvento(long id, CityEvent evento)
        {
            return _eventoRepository.AlterarEvento(id, evento);
        }

        public List<CityEvent> ConsultarEvento()
        {
            return _eventoRepository.ConsultarEvento();
        }

        public CityEvent ConsultarEventoPorID(long id)
        {
            return _eventoRepository.ConsultarEventoPorID(id);
        }

        public CityEvent ConsultarEventoPorTitulo(string titulo)
        {
            return _eventoRepository.ConsultarEventoPorTitulo(titulo);
        }

        public bool DeletarEvento(long id)
        {
            return _eventoRepository.DeletarEvento(id);
        }

        public bool InserirNovoEvento(CityEvent evento)
        {
            return _eventoRepository.InserirNovoEvento(evento);
        }
    }
}