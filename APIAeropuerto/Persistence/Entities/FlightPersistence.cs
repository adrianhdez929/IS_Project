using APIAeropuerto.Domain.Enums;

namespace APIAeropuerto.Persistence.Entities;

public class FlightPersistence
{
    public Guid Id { get; set; }
    public DateTime DepartureDate { get; set; }
    public DateTime ArrivalDate { get; set; }
    public DateTime Created { get; set; }
    public DateTime Updated { get; set; }
    public Guid IdAirportOrigin { get; set; }
    public virtual AirportPersistence AirportOrigin { get; set; }
    public Guid IdAirportDestination { get; set; }
    public virtual AirportPersistence AirportDestination { get; set; }
    public Guid IdClient { get; set; }
    public virtual ClientPersistence Client { get; set; }
    public Guid IdShip { get; set; }
    public virtual ShipPersistence Ship { get; set; }
    
    public ArrivedClientType ArrivedClientType { get; set; }
}