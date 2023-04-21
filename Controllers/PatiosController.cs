using api_ventas_por_oferta.Core.Dto;
using api_ventas_por_oferta.Core.Entity;
using api_ventas_por_oferta.Core.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace api_ventas_por_oferta.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PatiosController : ControllerBase
{
    IPatioService _service;
    IMapper _mapper;

    public PatiosController(
        IPatioService service
    , IMapper mapper
    )
    {
        _service = service;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<PatioResponseDto>>> ObtenerTodos()
    {
        var rta = await _service.ObtenerPatios();
        return Ok(_mapper.Map<IEnumerable<PatioResponseDto>>(rta));
        // return Ok(rta);
    }

    [HttpGet("autos")]
    public async Task<ActionResult<IEnumerable<PatioAutoResponseDto>>> ObtenerTodosConAutos()
    {
        var rta = await _service.ObtenerPatios();
        return Ok(_mapper.Map<IEnumerable<PatioAutoResponseDto>>(rta));
        // return Ok(rta);
    }

    [HttpGet("{patioId}")]
    public async Task<IActionResult> ObtenerPorId(int patioId)
    {
        var patio = await _service.ObtenerPatioPorId(patioId);
        if (patio == null)
        {
            return NotFound();
        }

        return Ok(_mapper.Map<PatioAutoResponseDto>(patio));

        // return Ok(patio);
    }

    [HttpPost]
    public async Task<ActionResult<Patio>> Crear(PatioCreateDto patioDto)
    {
        var nuevoPatio = new Patio
        {
            Nombre = patioDto.Nombre
        };
        var rta = await _service.CrearPatio(nuevoPatio);
        return Ok(_mapper.Map<PatioResponseDto>(rta));

        // return Ok(rta);
    }



    [HttpPut("{patioId}")]
    public async Task<IActionResult> Actualizar(int patioId, PatioCreateDto patioActualizado)
    {
        var patioexistente = await _service.ObtenerPatioPorId(patioId);
        if (patioexistente == null)
        {
            return NotFound();
        }
        patioexistente.Nombre = patioActualizado.Nombre;

        // Actualizar otras propiedades del cliente
        await _service.ActualizarPatio(patioexistente);

        return Ok(_mapper.Map<PatioResponseDto>(patioexistente));

        // return Ok(patioexistente);
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
