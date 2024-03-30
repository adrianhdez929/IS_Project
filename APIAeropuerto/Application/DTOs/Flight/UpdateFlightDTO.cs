using APIAeropuerto.Domain.Enums;

namespace APIAeropuerto.Application.DTOs.Flight;

public class UpdateFlightDTO
{
    public Guid Id { get; set; }
    public DateTime DepartureDate { get; set; }
    public DateTime ArrivalDate { get; set; }
    public Guid AirportOrigin { get; set; }
    public Guid AirportDestination { get; set; }
    public Guid Ship { get; set; }
    
    public ArrivedClientType ArrivedClientType { get; set; }
}