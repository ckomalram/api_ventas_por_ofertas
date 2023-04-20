using api_ventas_por_oferta.Core.Entity;

namespace api_ventas_por_oferta.Core.Interfaces;

public interface IClienteService
{
    Task<IEnumerable<Cliente>> ObtenerClientes();
    Task<Cliente> ObtenerClientePorId(int clienteId);
    Task<Cliente> CrearCliente(Cliente cliente);

    Task ActualizarCliente(Cliente cliente);

    Task EliminarCliente(int clienteId);

}