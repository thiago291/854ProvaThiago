using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using WebAPI_2608.Core.Interface;
using WebAPI_2608.Core.Model;

namespace WebAPI_2608.Infra.Data.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly IConfiguration _configuration;
        public ClienteRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public List<ClienteID> ConsultarClientes()
        {
            var query = "SELECT * FROM clientes";

            using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

            return conn.Query<ClienteID>(query).ToList();
        }

        public bool InserirClientes(Cliente cliente)
        {
            var query = $"INSERT INTO clientes VALUES (@cpf, @nome, @dataNascimento, @idade)";
            var parameters = new DynamicParameters();
            parameters.Add("cpf", cliente.CPF);
            parameters.Add("nome", cliente.Nome);
            parameters.Add("dataNascimento", cliente.DataNascimento);
            parameters.Add("idade", cliente.Idade);

            using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

            return conn.Execute(query, parameters) > 0;
        }

        public bool DeletarClientes(long id)
        {
            var query = $"DELETE FROM clientes WHERE id = @id";
            var parameters = new DynamicParameters();
            parameters.Add("id", id);
            using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

            return conn.Execute(query, parameters) == 1;
        }

        public bool AlterarClientes(long id, Cliente cliente)
        {
            var query = $"UPDATE clientes SET cpf = @cpf, nome = @nome, dataNascimento = @dataNascimento, idade = @idade WHERE id = @id";
            var parameters = new DynamicParameters();
            parameters.Add("cpf", cliente.CPF);
            parameters.Add("nome", cliente.Nome);
            parameters.Add("dataNascimento", cliente.DataNascimento);
            parameters.Add("idade", cliente.Idade);
            parameters.Add("id", id);
            using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

            return conn.Execute(query, parameters) > 0;
        }
    }
}
