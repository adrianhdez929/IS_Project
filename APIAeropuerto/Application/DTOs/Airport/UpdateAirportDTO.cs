namespace APIAeropuerto.Application.DTOs.Airport;

public class UpdateAirportDTO
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Address { get; set; }
    public string? GeographicPosition { get; set; }
}