using APIAeropuerto.Domain.Enums;

namespace APIAeropuerto.Persistence.Entities;

public class ClientPersistence
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Nationality { get; set; }
    public ClientType Type { get; set; }
    public DateTime Created { get; set; }
    public DateTime Updated { get; set; }
    public virtual IEnumerable<ClientServicesPersistence> ClientServices { get; set; }
}