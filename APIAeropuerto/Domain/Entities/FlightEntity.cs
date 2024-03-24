using APIAeropuerto.Domain.Shared;

namespace APIAeropuerto.Domain.Entities;

public class FlightEntity : BaseEntity
{
    public DateTime DepartureDate { get; set; }
    public DateTime ArrivalDate { get; set; }
    public Guid IdAirportOrigin { get; set; }
    public virtual AirportEntity AirportOrigin { get; set; }
    public Guid IdAirportDestination { get; set; }
    public virtual AirportEntity AirportDestination { get; set; }
    public Guid IdClient { get; set; }
    public virtual ClientEntity Client { get; set; }
    public Guid IdShip { get; set; }
    public virtual ShipEntity Ship { get; set; }

    public FlightEntity(Guid id, DateTime departureDate, DateTime arrivalDate)
    {
        Id = id;
        DepartureDate = departureDate;
        ArrivalDate = arrivalDate;
        Created = DateTime.Now;
        Updated = DateTime.Now;
    }
   
    public static FlightWrapper Create(DateTime departureDate, DateTime arrivalDate)
    {
        var temp = new FlightEntity(Guid.NewGuid(), departureDate, arrivalDate);
        return new FlightWrapper()
        {
            Value = temp,
            ErrorMessage = string.Empty,
            IsSuccess = true
        };
    }
}