namespace APIAeropuerto.Persistence.Entities;

public class AirportPersistence
{
    public Guid Id { get; set; }
    public DateTime Created { get; set; }
    public DateTime Updated { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public string GeographicPosition { get; set; }
    public virtual IEnumerable<InstallationsPersistence> Installations { get; set; }
    public virtual IEnumerable<FlightPersistence> OriginFlights { get; set; }
    public virtual IEnumerable<FlightPersistence> DestinationFlights { get; set; }
}