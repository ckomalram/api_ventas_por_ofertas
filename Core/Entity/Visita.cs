namespace api_ventas_por_oferta.Core.Entity;
public class Visita
{
    public int Id { get; set; } // Identificador único de la visita
    public DateTime FechaDeVisita { get; set; } // Fecha de la visita

    public int ClienteId { get; set; } // Identificador único del cliente al que pertenece la visita
    public Cliente Cliente { get; set; } // Cliente al que pertenece la visita

    public int? AutoId { get; set; } // Identificador único del auto asociado a la oferta (puede ser nulo)
    public Auto Auto { get; set; } // Auto asociado a la oferta (opcional)

    public int? InmuebleId { get; set; } // Identificador único del inmueble asociado a la oferta (puede ser nulo)
    public Inmueble Inmueble { get; set; } // Inmueble asociado a la oferta (opcional)

    public int PatioId { get; set; }
    public Patio Patio { get; set; }

}