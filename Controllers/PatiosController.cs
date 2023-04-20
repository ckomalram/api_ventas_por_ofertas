using api_ventas_por_oferta.Core.Entity;
using api_ventas_por_oferta.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace api_ventas_por_oferta.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PatiosController : ControllerBase
{
    IPatioService _service;
    public PatiosController(IPatioService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Patio>>> ObtenerTodos()
    {
        var rta = await _service.ObtenerPatios();
        return Ok(rta);
    }

    [HttpPost]
    public async Task<IActionResult> Crear(Patio patio)
    {
        await _service.CrearPatio(patio);
        return Ok(patio);
    }

    [HttpGet("{patioId}")]
    public async Task<IActionResult> ObtenerPorId(int patioId)
    {
        var patio = await _service.ObtenerPatioPorId(patioId);
        if (patio == null)
        {
            return NotFound();
        }
        return Ok(patio);
    }

    [HttpPut("{patioId}")]
    public async Task<IActionResult> Actualizar(int patioId, Patio patioActualizado)
    {
        var patioexistente = await _service.ObtenerPatioPorId(patioId);
        if (patioexistente == null)
        {
            return NotFound();
        }
        patioexistente.Nombre = patioActualizado.Nombre;

        // Actualizar otras propiedades del cliente
        await _service.ActualizarPatio(patioexistente);
        return Ok(patioexistente);
    }

    [HttpDelete("{patioId}")]
    public async Task<IActionResult> Eliminar(int patioId)
    {
        var patioexistente = await _service.ObtenerPatioPorId(patioId);
        if (patioexistente == null)
        {
            return NotFound();
        }
        await _service.EliminarPatio(patioId);
        return NoContent();
    }


}
