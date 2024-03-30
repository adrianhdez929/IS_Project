namespace APIAeropuerto.Persistence.Entities;

public class ServiceTypePersistence
{
    public Guid Id { get; set; }
    public virtual IEnumerable<ServicesPersistence> Services { get; set; }
    public string Type { get; set; }
}