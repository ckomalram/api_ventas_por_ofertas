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

    public async Task ActualizarCliente(Cliente cliente)
    {
        _context.Entry(cliente).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task<Cliente> CrearCliente(Cliente cliente)
    {
        cliente.FechaDeRegistro = DateTime.Now;
        await _context.Clientes.AddAsync(cliente);
        await _context.SaveChangesAsync();

        return cliente;
    }

    public async Task EliminarCliente(int clienteId)
    {
        var clienteActual = await ObtenerClientePorId(clienteId);
        if (clienteActual != null)
        {
            _context.Clientes.Remove(clienteActual);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<Cliente> ObtenerClientePorId(int clienteId)
    {
        return await _context.Clientes.FindAsync(clienteId);
    }

    public async Task<IEnumerable<Cliente>> ObtenerClientes()
    {
        return await _context.Clientes.ToListAsync();
    }
}