using api_ventas_por_oferta.Core.Context;
using api_ventas_por_oferta.Core.Entity;
using api_ventas_por_oferta.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace api_ventas_por_oferta.Core.Services;

public class ClienteService : IClienteService
{
    private readonly BienesContext _context;

    public ClienteService(BienesContext context)
    {
        _context = context;
    }

    public Task ActualizarCliente(Cliente cliente)
    {
        throw new NotImplementedException();
    }

    public Task<Cliente> CrearCliente(Cliente cliente)
    {
        throw new NotImplementedException();
    }

    public Task EliminarCliente(int clienteId)
    {
        throw new NotImplementedException();
    }

    public Task<Cliente> ObtenerClientePorId(int clienteId)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Cliente>> ObtenerClientes()
    {
        return await _context.Clientes.ToListAsync();
    }
}