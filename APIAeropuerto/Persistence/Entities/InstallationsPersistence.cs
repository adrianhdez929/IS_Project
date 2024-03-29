using APIAeropuerto.Domain.Enums;

namespace APIAeropuerto.Persistence.Entities;

public class InstallationsPersistence
{
    public Guid Id { get; set; }
    public DateTime Created { get; set; }
    public DateTime Updated { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Location { get; set; }
    public virtual AirportPersistence Airport { get; set; }
    public virtual InstallationTypePersistence InstallationType { get; set; }
    public virtual IEnumerable<ServicesPersistence> Services { get; set; }
}