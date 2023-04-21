using api_ventas_por_oferta.Core.Entity;

namespace api_ventas_por_oferta.Core.Interfaces;

public interface IPatioService
{
    Task<IEnumerable<Patio>> ObtenerPatios();
    Task<Patio> ObtenerPatioPorId(int patioId);
    Task<Patio> CrearPatio(Patio patio);

    Task<bool> ActualizarPatio(Patio patio);

    Task<bool> EliminarPatio(int patioId);


}