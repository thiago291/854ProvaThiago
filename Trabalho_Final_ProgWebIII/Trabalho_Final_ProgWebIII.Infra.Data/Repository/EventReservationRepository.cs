using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Trabalho_Final_ProgWebIII.Core.Interface;
using Trabalho_Final_ProgWebIII.Core.Model;

namespace Trabalho_Final_ProgWebIII.Infra.Data.Repository
{
    public class EventReservationRepository : IEventReservationRepository
    {
        private readonly IConfiguration _configuration;
        public EventReservationRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public EventReservation ConsultarReserva(string nome, string titulo)
        {
            var query = "SELECT E.IdReservation, E.IdEvent, E.PersonName, E.Quantity, C.Title FROM EventReservation as E JOIN CityEvent as C ON E.IdEvent = C.IdEvent WHERE C.Title LIKE '%' + @titulo +'%' AND E.PersonName = @nome";
            var parameters = new DynamicParameters();
            parameters.Add("titulo", titulo);
            parameters.Add("nome", nome);
            try
            {
                using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
                return conn.QueryFirstOrDefault<EventReservation>(query, parameters);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao comunicar com o banco, mensagem {ex.Message}, stack trace {ex.StackTrace}");
                throw;
            }
        }

        public bool InserirNovaReserva(EventReservation reserva)
        {
            var query = $"INSERT INTO EventReservation VALUES (@IdEvent, @PersonName, @Quantity)";
            var parameters = new DynamicParameters();
            parameters.Add("IdEvent", reserva.IdEvent);
            parameters.Add("PersonName", reserva.PersonName);
            parameters.Add("Quantity", reserva.Quantity);
            try
            {
                using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
                return conn.Execute(query, parameters) > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao comunicar com o banco, mensagem {ex.Message}, stack trace {ex.StackTrace}");
                return false;
                throw;
            }
        }

        public bool DeletarReserva(long id)
        {
            var query = $"DELETE FROM EventReservation WHERE IdReservation = @id";
            var parameters = new DynamicParameters();
            parameters.Add("id", id);
            try
            {
                using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
                return conn.Execute(query, parameters) == 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao comunicar com o banco, mensagem {ex.Message}, stack trace {ex.StackTrace}");
                throw;
            }
        }

        public bool AlterarReserva(long id, EventReservation reserva)
        {
            var query = $"UPDATE EventReservation SET Quantity = @Quantity  WHERE IdReservation = @id";
            var parameters = new DynamicParameters();
            parameters.Add("Quantity", reserva.Quantity);
            parameters.Add("id", id);

            try
            {
                using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
                return conn.Execute(query, parameters) > 0;
            }

            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao comunicar com o banco, mensagem {ex.Message}, stack trace {ex.StackTrace}");
                throw;
            }
        }

        public bool EventoTemReserva(long id)
        {
            var query = "SELECT * FROM EventReservation WHERE IdEvent = @id";
            var parameters = new DynamicParameters();
            parameters.Add("id", id);
            try
            {
                using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
                if (conn.Query<EventReservation>(query, parameters).ToList().Count() == 0)
                    return false;
                return true;
            }

            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao comunicar com o banco, mensagem {ex.Message}, stack trace {ex.StackTrace}");
                return false;
                throw;
            }
        }

        public bool ConsultarReservaPorID(long id)
        {
            var query = "SELECT * FROM EventReservation WHERE IdReservation = @id";
            var parameters = new DynamicParameters();
            parameters.Add("id", id);
            try
            {
                using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

                if (conn.Query<EventReservation>(query, parameters).ToList().Count() == 0)
                    return false;
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao comunicar com o banco, mensagem {ex.Message}, stack trace {ex.StackTrace}");
                throw;
            }
        }
    }
}
