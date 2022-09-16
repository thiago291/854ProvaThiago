using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Trabalho_Final_ProgWebIII.Core.Interface;
using Trabalho_Final_ProgWebIII.Core.Model;

namespace Trabalho_Final_ProgWebIII.Infra.Data.Repository
{
    public class CityEventRepository : ICityEventRepository
    {
        private readonly IConfiguration _configuration;
        public CityEventRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public List<CityEvent> ConsultarEventoPorTitulo(string titulo)
        {
            var query = "SELECT * FROM CityEvent WHERE Title LIKE '%'+ @titulo +'%'";
            var parameters = new DynamicParameters();
            parameters.Add("titulo", titulo);
            try
            {
                using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
                return conn.Query<CityEvent>(query, parameters).ToList();
            }

            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao comunicar com o banco, mensagem {ex.Message}, stack trace {ex.StackTrace}");
                throw;
            }
        }

        public bool InserirNovoEvento(CityEvent evento)
        {
            var query = $"INSERT INTO CityEvent VALUES (@Title, @Description, @DateHourEvent, @Local, @Address, @Price, @Status)";
            var parameters = new DynamicParameters();
            parameters.Add("Title", evento.Title);
            parameters.Add("Description", evento.Description);
            parameters.Add("DateHourEvent", evento.DateHourEvent);
            parameters.Add("Local", evento.Local);
            parameters.Add("Address", evento.Address);
            parameters.Add("Price", evento.Price);
            parameters.Add("Status", evento.Status);
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

        public bool DeletarEvento(long id)
        {

            var query = $"DELETE FROM CityEvent WHERE IdEvent = @id";
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

        public bool AlterarEvento(long id, CityEvent evento)
        {
            var query = $"UPDATE CityEvent SET Title = @Title, Description = @Description, DateHourEvent = @DateHourEvent, Local = @Local, Address = @Address, Price = @Price, Status = @Status  WHERE IdEvent = @id";
            var parameters = new DynamicParameters();
            parameters.Add("Title", evento.Title);
            parameters.Add("Description", evento.Description);
            parameters.Add("DateHourEvent", evento.DateHourEvent);
            parameters.Add("Local", evento.Local);
            parameters.Add("Address", evento.Address);
            parameters.Add("Price", evento.Price);
            parameters.Add("Status", evento.Status);
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

        public bool AlterarEvento(long id)
        {
            var query = $"UPDATE CityEvent SET Status = 0  WHERE IdEvent = @id";
            var parameters = new DynamicParameters();
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

        public List<CityEvent> ConsultarEventoPorLocal(string local, DateTime date)
        {
            var query = "SELECT * FROM CityEvent WHERE LOWER(Local) = LOWER(@local) and CAST(DateHourEvent as DATE) = Cast(@date as DATE)";
            var parameters = new DynamicParameters();
            parameters.Add("local", local);
            parameters.Add("date", date);
            try
            {
                using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
                return conn.Query<CityEvent>(query, parameters).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao comunicar com o banco, mensagem {ex.Message}, stack trace {ex.StackTrace}");
                throw;
            }
        }

        public List<CityEvent> ConsultarEventoPorRange(double minValor, double maxValor, DateTime date)
        {
            var query = "SELECT * FROM CityEvent WHERE CAST(DateHourEvent as DATE) = Cast(@date as DATE) AND Price BETWEEN @minValor AND @maxValor";
            var parameters = new DynamicParameters();
            parameters.Add("minValor", minValor);
            parameters.Add("maxValor", maxValor);
            parameters.Add("date", date);
            try
            {
                using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
                return conn.Query<CityEvent>(query, parameters).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao comunicar com o banco, mensagem {ex.Message}, stack trace {ex.StackTrace}");
                throw;
            }
        }

        public bool ConsultarEventoPorID(long id)
        {
            var query = "SELECT * FROM CityEvent WHERE IdEvent = @id";
            var parameters = new DynamicParameters();
            parameters.Add("id", id);
            try
            {
                using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
                if (conn.Query<EventReservation>(query, parameters).ToList().Count == 0)
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
