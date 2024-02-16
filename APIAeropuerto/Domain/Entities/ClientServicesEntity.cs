using APIAeropuerto.Domain.Shared;

namespace APIAeropuerto.Domain.Entities;

public class ClientServicesEntity
{
    public ClientServicesEntity()
    {
        
    }

    public ClientServicesEntity(Guid idClient, string idService)
    {
        IdClient = idClient;
        IdService = idService;
        Created = DateTime.Now;
        Updated = DateTime.Now;
    }
    public static ClientServicesWrapper Create(Guid idClient, string idService)
    {
        var temp = new ClientServicesEntity(idClient, idService);
        return new ClientServicesWrapper()
        {
            Value = temp,
            ErrorMessage = string.Empty,
            IsSuccess = true
        };
    }
    public Guid IdClient { get; set; }
    public ClientEntity Client { get; set; }
    public string IdService { get; set; }
    public ServicesEntity Service { get; set; }
    public DateTime Created { get; set; }
    public DateTime Updated { get; set; }
}