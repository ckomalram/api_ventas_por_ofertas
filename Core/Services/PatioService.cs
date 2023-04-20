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

    public async Task ActualizarPatio(Patio patio)
    {
        _context.Entry(patio).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task<Patio> CrearPatio(Patio patio)
    {

        await _context.Patios.AddAsync(patio);
        await _context.SaveChangesAsync();

        return patio;
    }

    public async Task EliminarPatio(int patioId)
    {
        var patioActual = await ObtenerPatioPorId(patioId);
        if (patioActual != null)
        {
            _context.Patios.Remove(patioActual);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<Patio> ObtenerPatioPorId(int patioId)
    {
        return await _context.Patios.FindAsync(patioId);

    }

    public async Task<IEnumerable<Patio>> ObtenerPatios()
    {
        return await _context.Patios.ToListAsync();

    }
}