namespace api_ventas_por_oferta.Core.Dto;


public class AutoCreateDto
{
    public string Marca { get; set; }
    public string Modelo { get; set; }
    public int Annio { get; set; }
    public decimal Precio { get; set; }

    public int PatioId { get; set; }

}

public class AutoUpdateDto
{
    public string Marca { get; set; }
    public string Modelo { get; set; }
    public int Annio { get; set; }
    public decimal Precio { get; set; }

    public int PatioId { get; set; }

}


public class AutoResponseDto
{
    public int Id { get; set; }
    public string Marca { get; set; }
    public string Modelo { get; set; }
    public int Annio { get; set; }
    public decimal Precio { get; set; }
    public int PatioId { get; set; }
    public string PatioNombre { get; set; }

}