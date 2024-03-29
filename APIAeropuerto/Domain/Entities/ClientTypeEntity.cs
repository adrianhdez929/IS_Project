namespace APIAeropuerto.Domain.Entities;

public class ClientTypeEntity : BaseTypeEntity
{
    public virtual IEnumerable<ClientEntity> Clients { get; set; }

    public static ClientTypeEntity Create(string type)
    {
        return new ClientTypeEntity
        {
            Id = Guid.NewGuid(),
            Type = type
        };
    }
}