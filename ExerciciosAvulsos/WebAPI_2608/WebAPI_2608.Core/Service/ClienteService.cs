using WebAPI_2608.Core.Interface;
using WebAPI_2608.Core.Model;

namespace WebAPI_2608.Core.Service
{
    public class ClienteService : IClienteService
    {
        public IClienteRepository _clienteRepository;
        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public bool AlterarClientes(long id, Cliente cliente)
        {
            return _clienteRepository.AlterarClientes(id,cliente);
        }

        public List<ClienteID> ConsultarClientes()
        {
            return _clienteRepository.ConsultarClientes();
        }

        public bool DeletarClientes(long id)
        {
            return _clienteRepository.DeletarClientes(id);
        }

        public bool InserirClientes(Cliente cliente)
        {
            return _clienteRepository.InserirClientes(cliente);
        }
    }
}