namespace api_ventas_por_oferta.Core.Dto;


public class PatioCreateDto
{
    public string Nombre { get; set; }

}

public class PatioResponseDto
{
    public int Id { get; set; }
    public string Nombre { get; set; }

}

public class PatioAutoResponseDto
{
    public int Id { get; set; }
    public string Nombre { get; set; }

    public List<AutoPatioResponseDto> Autos { get; set; } // Lista de autos en el patio


}