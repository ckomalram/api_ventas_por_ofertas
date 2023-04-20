namespace api_ventas_por_oferta.Core.Entity;


public class Patio
{
    public int Id { get; set; } // Identificador único del patio
    public string Nombre { get; set; } // Nombre del patio
    public List<Auto> Autos { get; set; } // Lista de autos en el patio

    // Propiedad de navegacion
    // public List<Visita> Visitas { get; set; }

}