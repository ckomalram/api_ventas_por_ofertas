namespace api_ventas_por_oferta.Core.Entity;
public class Auto
{
    public int Id { get; set; } // Identificador único del auto
    public string Marca { get; set; } // Marca del auto
    public string Modelo { get; set; } // Modelo del auto
    public int Annio { get; set; } // Año de fabricación del auto
    public decimal Precio { get; set; } // Precio de venta del auto


    // propiedad de navegación
    public int PatioId { get; set; }
    public Patio Patio { get; set; }

    // Propiedad de navegacion
    public List<Oferta> Ofertas { get; set; }
    public List<Visita> Visitas { get; set; }


}