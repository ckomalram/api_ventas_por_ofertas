using api_ventas_por_oferta.Core.Context;
using api_ventas_por_oferta.Core.Entity;
using api_ventas_por_oferta.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace api_ventas_por_oferta.Core.Services;

public class PatioService : IPatioService
{
    private readonly BienesContext _context;

    public PatioService(BienesContext context)
    {
        _context = context;
    }

    public async Task<bool> ActualizarPatio(Patio patio)
    {
        _context.Entry(patio).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
            return true;

        }
        catch (DbUpdateConcurrencyException)
        {
            return false;
        }
    }

    public async Task<Patio> CrearPatio(Patio patio)
    {
        await _context.Patios.AddAsync(patio);
        await _context.SaveChangesAsync();

        return patio;
    }

    public async Task<bool> EliminarPatio(int patioId)
    {
        //TODO: No dejar eliminar si tiene autos asociados.

        var patioActual = await ObtenerPatioPorId(patioId);
        if (patioActual != null && patioActual.Autos.Any())
        {
            throw new Exception("Patio cuenta con autos , favor cambiarlos a otro patio antes de elimnar este.");
        }

        if (patioActual != null)
        {
            _context.Patios.Remove(patioActual);
            await _context.SaveChangesAsync();
            return true;
        }

        return false;
    }

    public async Task<Patio> ObtenerPatioPorId(int patioId)
    {
        var patio = await _context.Patios
                        .Include(a => a.Autos)
                        .FirstOrDefaultAsync(a => a.Id == patioId);
        return patio;
        // return await _context.Patios.FindAsync(patioId);

    }

    public async Task<IEnumerable<Patio>> ObtenerPatios()
    {
        return await _context.Patios
            .Include(a => a.Autos)
            .ToListAsync();

    }
}