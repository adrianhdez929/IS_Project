using APIAeropuerto.Domain.Entities;
using APIAeropuerto.Domain.Enums;

namespace APIAeropuerto.Persistence.Entities;

public class ClientPersistence
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Nationality { get; set; }
    public DateTime Created { get; set; }
    public DateTime Updated { get; set; }
    public Guid IdUser { get; set; }
    public virtual UserPersistence User { get; set; }
    public virtual ClientTypePersistence ClientType { get; set; }
    public virtual IEnumerable<ClientServicesPersistence> ClientServices { get; set; }
    public virtual IEnumerable<FlightPersistence> Flights { get; set; }
}