namespace api_ventas_por_oferta.Core.Entity;

public class Cliente
{
    public int Id { get; set; } // Identificador único del cliente
    public string Nombre { get; set; } // Nombre del cliente
    public string Apellido { get; set; } // Apellido del cliente
    public string CorreoElectronico { get; set; } // Correo electrónico del cliente
    public string Telefono { get; set; } // Número de teléfono del cliente
    public string Direccion { get; set; } // Dirección del cliente
    public DateTime FechaDeRegistro { get; set; } // Fecha de registro del cliente en el sistema

    // Propiedad de navegacion
    public List<Visita> Visitas { get; set; }
    public List<Oferta> Ofertas { get; set; }
}