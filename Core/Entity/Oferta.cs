namespace api_ventas_por_oferta.Core.Entity;
public class Oferta
{
    public int Id { get; set; } // Identificador único de la oferta
    public decimal Monto { get; set; } // Monto ofrecido en la oferta
    public DateTime FechaDeOferta { get; set; } // Fecha de la oferta

    //definiendo Relaciones
    public int ClienteId { get; set; } // Identificador único del cliente que realizó la oferta
    public Cliente Cliente { get; set; } // Cliente que realizó la oferta

    public int? AutoId { get; set; } // Identificador único del auto asociado a la oferta (puede ser nulo)
    public Auto Auto { get; set; } // Auto asociado a la oferta (opcional)

    public int? InmuebleId { get; set; } // Identificador único del inmueble asociado a la oferta (puede ser nulo)
    public Inmueble Inmueble { get; set; } // Inmueble asociado a la oferta (opcional)

}