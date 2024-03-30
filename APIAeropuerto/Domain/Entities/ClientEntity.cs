using APIAeropuerto.Domain.Enums;
using APIAeropuerto.Domain.Shared;

namespace APIAeropuerto.Domain.Entities;

public class ClientEntity : BaseEntity
{
    public ClientEntity()
    {
        
    }

    public ClientEntity(Guid id,string name, string nationality, ClientTypeEntity type)
    {
        Id = id;
        Name = name;
        Nationality = nationality;
        ClientType = type;
        Created = DateTime.Now;
        Updated = DateTime.Now;
    }

    public static ClientWrapper Create(string name, string nationality, ClientTypeEntity type)
    {
        var temp = new ClientEntity(Guid.NewGuid(), name, nationality, type);
        return new ClientWrapper()
        {
            Value = temp,
            ErrorMessage = string.Empty,
            IsSuccess = true
        };
    }

    public void Update (string name, string nationality, ClientTypeEntity type)
    {
        Name = name;
        Nationality = nationality;
        ClientType = type;
        Updated = DateTime.Now;
    }
    public void AddService(ClientServicesEntity clientServicesEntity)
    {
        ((List<ClientServicesEntity>)ClientServices).Add(clientServicesEntity);
    }
    public string Name { get; set; }
    public string Nationality { get; set; }
    public Guid IdUser { get; set; }
    public virtual UsersEntity User { get; set; }
    public virtual ClientTypeEntity ClientType { get; set; }
    public virtual IEnumerable<ClientServicesEntity> ClientServices { get; set; }
    public virtual IEnumerable<FlightEntity> Flights { get; set; }
}