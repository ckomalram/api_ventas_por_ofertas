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
}
