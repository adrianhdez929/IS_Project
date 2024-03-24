namespace APIAeropuerto.Application.DTOs.Flight;

public class CreateFlightDTO
{
    public DateTime DepartureDate { get; set; }
    public DateTime ArrivalDate { get; set; }
    public Guid AirportOrigin { get; set; }
    public Guid AirportDestination { get; set; }
    public Guid Ship { get; set; }
    public Guid Client { get; set; }
}