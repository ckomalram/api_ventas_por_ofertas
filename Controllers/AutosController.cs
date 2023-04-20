using api_ventas_por_oferta.Core.Dto;
using api_ventas_por_oferta.Core.Entity;
using api_ventas_por_oferta.Core.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace api_ventas_por_oferta.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AutosController : ControllerBase
{
    IAutoService _service;
    IMapper _mapper;
    public AutosController(IAutoService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<AutoResponseDto>>> ObtenerTodos()
    {
        var rta = await _service.ObtenerTodos();

        return Ok(_mapper.Map<IEnumerable<AutoResponseDto>>(rta));
    }

    [HttpGet("{autoId}")]
    public async Task<ActionResult<AutoResponseDto>> ObtenerPorId(int autoId)
    {
        var auto = await _service.ObtenerPorId(autoId);
        if (auto == null)
        {
            return NotFound();
        }
        return Ok(_mapper.Map<AutoResponseDto>(auto));

    }

    [HttpGet("patio/{patioId}")]
    public async Task<ActionResult<IEnumerable<AutoResponseDto>>> ObtenerPorPatio(int patioId)
    {
        var autos = await _service.ObtenerPorPatio(patioId);
        // return Ok(autos);
        return Ok(_mapper.Map<IEnumerable<AutoResponseDto>>(autos));

    }


    [HttpPost]
    public async Task<IActionResult> Crear(AutoCreateDto nuevoAutoDto)
    {
        var nuevoAuto = new Auto
        {
            Marca = nuevoAutoDto.Marca,
            Modelo = nuevoAutoDto.Modelo,
            Annio = nuevoAutoDto.Annio,
            Precio = nuevoAutoDto.Precio,
            PatioId = nuevoAutoDto.PatioId
        };
        await _service.Crear(nuevoAuto);

        return Ok(_mapper.Map<AutoResponseDto>(nuevoAuto));
        // return Ok(nuevoAuto);
    }




    [HttpPut("{autoId}")]
    public async Task<IActionResult> Actualizar(int autoId, AutoUpdateDto autoActualizado)
    {
        var autoExistente = await _service.ObtenerPorId(autoId);
        if (autoExistente == null)
        {
            return NotFound();
        }
        autoExistente.Marca = autoActualizado.Marca;
        autoExistente.Modelo = autoActualizado.Modelo;
        autoExistente.Annio = autoActualizado.Annio;
        autoExistente.Precio = autoActualizado.Precio;
        autoExistente.PatioId = autoActualizado.PatioId;

        // Actualizar otras propiedades del cliente
        await _service.Actualizar(autoExistente);

        return Ok(_mapper.Map<AutoResponseDto>(autoExistente));
        // return Ok(autoExistente);
    }

    [HttpDelete("{autoId}")]
    public async Task<IActionResult> Eliminar(int autoId)
    {
        var autoExistente = await _service.ObtenerPorId(autoId);
        if (autoExistente == null)
        {
            return NotFound();
        }
        await _service.Eliminar(autoId);
        return NoContent();
    }


}
