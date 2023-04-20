namespace api_ventas_por_oferta.Core.Entity;
public class Inmueble
{
    public int Id { get; set; } // Identificador único del inmueble
    public string Tipo { get; set; } // Tipo de inmueble (casa, departamento, etc.)
    public string Direccion { get; set; } // Dirección del inmueble
    public decimal Precio { get; set; } // Precio de venta del inmueble
    public int Habitaciones { get; set; } // Número de habitaciones del inmueble
    public int Bannio { get; set; } // Número de baños del inmueble

    // Propiedad de navegacion

    public List<Oferta> Ofertas { get; set; }

}