namespace APIAeropuerto.Persistence.Entities;

public class ClientTypePersistence
{
    public Guid Id { get; set; }
    public string Type { get; set; }
    public virtual IEnumerable<ClientPersistence> Clients { get; set; }
}