﻿using WebAPI_2608.Core.Model;

namespace WebAPI_2608.Core.Interface
{
    public interface IClienteService
    {
        List<ClienteID> ConsultarClientes();
        ClienteID ConsultarClientesCPF(string cpf);
        bool InserirClientes(Cliente cliente);
        bool DeletarClientes(long id);
        bool AlterarClientes(long id, Cliente cliente);
    }
}