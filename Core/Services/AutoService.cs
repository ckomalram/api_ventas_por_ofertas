using System.Text.Json;
using System.Text.Json.Serialization;
using api_ventas_por_oferta.Core.Context;
using api_ventas_por_oferta.Core.Dto;
using api_ventas_por_oferta.Core.Entity;
using api_ventas_por_oferta.Core.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace api_ventas_por_oferta.Core.Services;

public class AutoService : IAutoService
{
    private readonly BienesContext _context;



    public AutoService(BienesContext context)
    {
        _context = context;

    }

    public async Task<bool> Actualizar(Auto auto)
    {
        _context.Entry(auto).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
            return true;
        }
        catch (DbUpdateConcurrencyException)
        {
            return false;
        }
        // await _context.SaveChangesAsync();
    }

    public async Task Crear(Auto auto)
    {
        var patioExistente = await _context.Patios.FindAsync(auto.PatioId);
        if (patioExistente == null) throw new ArgumentException("El Patio especificado no existe.");
        //  auto.Patio = patioExistente;
        await _context.Autos.AddAsync(auto);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> Eliminar(int autoId)
    {
        var autoActual = await ObtenerPorId(autoId);
        if (autoActual != null)
        {
            _context.Autos.Remove(autoActual);
            await _context.SaveChangesAsync();
            return true;
        }

        return false;
    }

    public async Task<Auto> ObtenerPorId(int autoId)
    {
        var auto = await _context.Autos
        .Include(a => a.Patio)
        .FirstOrDefaultAsync(a => a.Id == autoId);

        // var autoRta = _mapper.Map<AutoResponseDto>(auto);

        return auto;




    }

    public async Task<IEnumerable<Auto>> ObtenerTodos()
    {
        var autoRta = await _context.Autos
           .Include(a => a.Patio).ToListAsync();
        return autoRta;
        // return _mapper.Map<IEnumerable<AutoResponseDto>>(autoRta);
    }

    public async Task<IEnumerable<Auto>> ObtenerPorPatio(int patioId)
    {
        var autoRta = await _context.Autos
            .Include(a => a.Patio)
            .Where(a => a.PatioId == patioId)
            .ToListAsync();

        return autoRta;
        // return _mapper.Map<IEnumerable<AutoResponseDto>>(autoRta);
    }


}