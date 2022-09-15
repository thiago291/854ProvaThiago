using Trabalho_Final_ProgWebIII.Core.Model;

namespace Trabalho_Final_ProgWebIII.Core.Interface
{
    public interface IEventoRepository
    {
        public List<CityEvent> ConsultarEvento();
        public CityEvent ConsultarEventoPorTitulo(string titulo);
        public bool InserirNovoEvento(CityEvent evento);
        public bool DeletarEvento(long id);
        public bool AlterarEvento(long id, CityEvent evento);
        public CityEvent ConsultarEventoPorID(long id);
    }
}
