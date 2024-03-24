using APIAeropuerto.Domain.Shared;

namespace APIAeropuerto.Domain.Entities;

public class AirportEntity : BaseEntity
{
    public AirportEntity()
    {
        
    }
    private AirportEntity(Guid id, string name, string address, string geographicPosition,List<InstallationsEntity> installations)
    {
        Id = id;
        Name = name;
        Address = address;
        GeographicPosition = geographicPosition;
        Installations = installations;
        Created = DateTime.UtcNow;
        Updated = DateTime.UtcNow;
    }
    public static AirportWrapper Create(string name, string address, string geographicPosition, List<InstallationsEntity> installations)
    {
        var aeropuerto = new AirportEntity(Guid.NewGuid(), name, address, geographicPosition, installations);
        return new AirportWrapper
        {
            IsSuccess = true,
            ErrorMessage = string.Empty,
            Value = aeropuerto,
        };
    }
    public void Update(string name, string address, string geographicPosition)
    {
        Name = name;
        Address = address;
        GeographicPosition = geographicPosition;
        Updated = DateTime.UtcNow;
    }
    public string Name { get; set; }
    public string Address { get; set; }
    public string GeographicPosition { get; set; }
    public virtual IEnumerable<InstallationsEntity> Installations { get; private set; }
    public virtual IEnumerable<FlightEntity> OriginFlights { get; private set; }
    public virtual IEnumerable<FlightEntity> DestinationFlights { get; private set; }
}