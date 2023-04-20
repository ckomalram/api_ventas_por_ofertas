using api_ventas_por_oferta.Core.Entity;
using api_ventas_por_oferta.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace api_ventas_por_oferta.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClientesController : ControllerBase
{
    IClienteService _service;
    public ClientesController(IClienteService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Cliente>>> GetAll()
    {
        var rta = await _service.ObtenerClientes();
        return Ok(rta);
    }

    [HttpPost]
    public async Task<IActionResult> CrearCliente(Cliente cliente)
    {
        await _service.CrearCliente(cliente);
        return Ok(cliente);
    }

    [HttpGet("{clienteId}")]
    public async Task<IActionResult> ObtenerCliente(int clienteId)
    {
        var cliente = await _service.ObtenerClientePorId(clienteId);
        if (cliente == null)
        {
            return NotFound();
        }
        return Ok(cliente);
    }

    [HttpPut("{clienteId}")]
    public async Task<IActionResult> ActualizarCliente(int clienteId, Cliente clienteActualizado)
    {
        var clienteExistente = await _service.ObtenerClientePorId(clienteId);
        if (clienteExistente == null)
        {
            return NotFound();
        }
        clienteExistente.Nombre = clienteActualizado.Nombre;
        clienteExistente.Apellido = clienteActualizado.Apellido;
        clienteExistente.CorreoElectronico = clienteActualizado.CorreoElectronico;
        clienteExistente.Telefono = clienteActualizado.Telefono;
        clienteExistente.Direccion = clienteActualizado.Direccion;
        // Actualizar otras propiedades del cliente
        await _service.ActualizarCliente(clienteExistente);
        return Ok(clienteExistente);
    }

    [HttpDelete("{clienteId}")]
    public async Task<IActionResult> EliminarCliente(int clienteId)
    {
        var clienteExistente = await _service.ObtenerClientePorId(clienteId);
        if (clienteExistente == null)
        {
            return NotFound();
        }
        await _service.EliminarCliente(clienteId);
        return NoContent();
    }


}
