using api_ventas_por_oferta.Core.Dto;
using api_ventas_por_oferta.Core.Entity;

namespace api_ventas_por_oferta.Core.Interfaces;

public interface IAutoService
{
    Task<IEnumerable<Auto>> ObtenerTodos();
    Task<Auto> ObtenerPorId(int autoId);
    Task Crear(Auto auto);

    Task<bool> Actualizar(Auto auto);

    Task<bool> Eliminar(int autoId);

    Task<IEnumerable<Auto>> ObtenerPorPatio(int patioId);


}