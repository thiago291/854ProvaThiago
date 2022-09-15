using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Trabalho_Final_ProgWebIII.Core.Interface;
using Trabalho_Final_ProgWebIII.Core.Model;

namespace Trabalho_Final_ProgWebIII.Infra.Data.Repository
{
    public class EventoRepository : IEventoRepository
    {
        private readonly IConfiguration _configuration;
        public EventoRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public List<CityEvent> ConsultarEvento()
        {
            var query = "SELECT * FROM CityEvent";

            using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

            return conn.Query<CityEvent>(query).ToList();
        }

        public CityEvent ConsultarEventoPorTitulo(string titulo)
        {
            var query = "SELECT * FROM CityEvent WHERE Title = @titulo";
            var parameters = new DynamicParameters();
            parameters.Add("titulo", titulo);

            using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

            return conn.QueryFirstOrDefault<CityEvent>(query, parameters);
        }

        public bool InserirNovoEvento(CityEvent evento)
        {
            var query = $"INSERT INTO CityEvent VALUES (@Title, @Description, @DateHourEvent, @Local, @Address, @Price)";
            //var query = $"INSERT INTO CityEvent VALUES (@Title, @Description, @DateHourEvent, @Local, @Address, @Price, @Status)";
            var parameters = new DynamicParameters();
            parameters.Add("Title", evento.Title);
            parameters.Add("Description", evento.Description);
            parameters.Add("DateHourEvent", evento.DateHourEvent);
            parameters.Add("Local", evento.Local);
            parameters.Add("Address", evento.Address);
            parameters.Add("Price", evento.Price);
            //parameters.Add("Status", evento.Status);

            using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

            return conn.Execute(query, parameters) > 0;
        }

        public bool DeletarEvento(long id)
        {
            var query = $"DELETE FROM CityEvent WHERE IdEvent = @id";
            var parameters = new DynamicParameters();
            parameters.Add("id", id);
            using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

            return conn.Execute(query, parameters) == 1;
        }

        public bool AlterarEvento(long id, CityEvent evento)
        {
            var query = $"UPDATE CityEvent SET Title = @Title, Description = @Description, DateHourEvent = @DateHourEvent, Local = @Local, Address = @Address, Price = @Price  WHERE IdEvent = @id";
            //var query = $"UPDATE CityEvent SET Title = @Title, Description = @Description, DateHourEvent = @DateHourEvent, Local = @Local, Address = @Address, Price = @Price, Status = @Status  WHERE IdEvent = @id";
            var parameters = new DynamicParameters();
            parameters.Add("Title", evento.Title);
            parameters.Add("Description", evento.Description);
            parameters.Add("DateHourEvent", evento.DateHourEvent);
            parameters.Add("Local", evento.Local);
            parameters.Add("Address", evento.Address);
            parameters.Add("Price", evento.Price);
            //parameters.Add("Status", evento.Status);
            parameters.Add("id", id);
            using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

            return conn.Execute(query, parameters) > 0;
        }

        public CityEvent ConsultarEventoPorID(long id)
        {
            var query = "SELECT * FROM CityEvent WHERE IdEvent = @id";
            var parameters = new DynamicParameters();
            parameters.Add("id", id);

            using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

            return conn.QueryFirstOrDefault<CityEvent>(query, parameters);
        }
    }
}
