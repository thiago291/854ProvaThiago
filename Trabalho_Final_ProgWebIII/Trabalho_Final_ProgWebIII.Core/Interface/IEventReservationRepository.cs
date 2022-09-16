using Trabalho_Final_ProgWebIII.Core.Model;

namespace Trabalho_Final_ProgWebIII.Core.Interface
{
    public interface IEventReservationRepository
    {
        public EventReservation ConsultarReserva(string nome, string titulo);
        public bool InserirNovaReserva(EventReservation reserva);
        public bool DeletarReserva(long id);
        public bool AlterarReserva(long id, EventReservation reserva);
        public bool EventoTemReserva(long id);

    }
}
