using Microsoft.AspNetCore.Mvc;

namespace WebAPI_2608.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController : ControllerBase
    {

        private readonly ILogger<ClienteController> _logger;

        public List<Cliente> clientes { get; set; }
        
        public ClienteController(ILogger<ClienteController> logger)
        {
            _logger = logger;
            clientes = Enumerable.Range(1, 10).Select(i => new Cliente
            {
                DataDeNascimento = DateTime.Now.AddYears(-18 - i),
                Nome = "João Silva número " + i,
                CPF = (99999999999 - i).ToString(),
                Idade = DateTime.Now.Year - DateTime.Now.AddYears(-18 -i).Year
            }).ToList();
        }

        [HttpGet]
        public List<Cliente> Consulta(int index)
        {
            return clientes;
        }

        [HttpPost]
        public Cliente Post(Cliente cliente)
        {
            clientes.Add(cliente);
            return cliente;
        }

        [HttpPut]
        public Cliente Atualizar(int index, Cliente cliente)
        {
            clientes[index] = cliente;
            return clientes[index];
        }

        [HttpDelete]
        public List<Cliente> Deletar(int index)
        {
            clientes.RemoveAt(index);
            return clientes;
        }
    }
}