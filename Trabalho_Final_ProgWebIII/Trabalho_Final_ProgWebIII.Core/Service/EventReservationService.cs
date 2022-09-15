using Trabalho_Final_ProgWebIII.Core.Interface;
using Trabalho_Final_ProgWebIII.Core.Model;

namespace Trabalho_Final_ProgWebIII.Core.Service
{
    public class EventReservationService : IEventReservationService
    {
        public IEventReservationRepository _reservaRepository;
        public EventReservationService(IEventReservationRepository reservaRepository)
        {
            _reservaRepository = reservaRepository;
        }

        public bool AlterarReserva(long id, EventReservation evento)
        {
            return _reservaRepository.AlterarReserva(id, evento);
        }

        public EventReservation ConsultarReserva(string nome, string titulo)
        {
            return _reservaRepository.ConsultarReserva(nome, titulo);
        }

        public bool DeletarReserva(long id)
        {
            return _reservaRepository.DeletarReserva(id);
        }

        public bool EventoTemReserva(long id)
        {
            return _reservaRepository.EventoTemReserva(id);
        }

        public bool InserirNovaReserva(EventReservation reserva)
        {
            return _reservaRepository.InserirNovaReserva(reserva);
        }
    }
}
