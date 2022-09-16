﻿using Trabalho_Final_ProgWebIII.Core.Interface;
using Trabalho_Final_ProgWebIII.Core.Model;

namespace Trabalho_Final_ProgWebIII.Core.Service
{
    public class CityEventService: ICityEventService
    {
        public ICityEventRepository _eventoRepository;
        public IEventReservationService _reservaService;
        public CityEventService(ICityEventRepository eventoRepository, IEventReservationService reservaService)
        {
            _eventoRepository = eventoRepository;
            _reservaService = reservaService; 
        }


        public bool AlterarEvento(long id, CityEvent evento)
        {
            return _eventoRepository.AlterarEvento(id, evento);
        }

        public bool AlterarEvento(long id)
        {
            return _eventoRepository.AlterarEvento(id);
        }

        public bool ConsultarEventoPorID(long id)
        {
            return _eventoRepository.ConsultarEventoPorID(id);
        }

        public List<CityEvent> ConsultarEventoPorLocal(string local, DateTime date)
        {
            return _eventoRepository.ConsultarEventoPorLocal(local, date);
        }

        public List<CityEvent> ConsultarEventoPorRange(double minValor, double maxValor, DateTime date)
        {
            return _eventoRepository.ConsultarEventoPorRange(minValor, maxValor, date);
        }

        public List<CityEvent> ConsultarEventoPorTitulo(string titulo)
        {
            return _eventoRepository.ConsultarEventoPorTitulo(titulo);
        }

        public bool DeletarEvento(long id)
        {
            if (_reservaService.EventoTemReserva(id))
                return _eventoRepository.AlterarEvento(id);
            return _eventoRepository.DeletarEvento(id);
        }

        public bool InserirNovoEvento(CityEvent evento)
        {
            return _eventoRepository.InserirNovoEvento(evento);
        }
    }
}