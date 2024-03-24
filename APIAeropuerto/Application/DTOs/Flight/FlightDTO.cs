using APIAeropuerto.Application.DTOs.Airport;
using APIAeropuerto.Application.DTOs.Client;
using APIAeropuerto.Application.DTOs.Ship;

namespace APIAeropuerto.Application.DTOs.Flight;

public class FlightDTO
{
    public DateTime DepartureDate { get; set; }
    public DateTime ArrivalDate { get; set; }
    public AirportDTO Origin { get; set; }
    public AirportDTO Destination { get; set; }
    public ShipDTO Ship { get; set; }
}