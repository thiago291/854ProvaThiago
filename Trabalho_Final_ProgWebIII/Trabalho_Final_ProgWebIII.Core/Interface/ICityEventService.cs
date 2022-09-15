using Trabalho_Final_ProgWebIII.Core.Model;

namespace Trabalho_Final_ProgWebIII.Core.Interface
{
    public interface ICityEventService
    {
        public List<CityEvent> ConsultarEventoPorTitulo(string titulo);
        public bool InserirNovoEvento(CityEvent evento);
        public bool DeletarEvento(long id);
        public bool AlterarEvento(long id, CityEvent evento);
        public bool AlterarEvento(long id);
        public List<CityEvent> ConsultarEventoPorLocal(string local, DateTime date);
        public List<CityEvent> ConsultarEventoPorRange(double minValor, double maxValor, DateTime date);
    }
}
