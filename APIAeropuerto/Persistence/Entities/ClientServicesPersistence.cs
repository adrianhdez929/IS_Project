using System.ComponentModel.DataAnnotations;

namespace APIAeropuerto.Persistence.Entities;

public class ClientServicesPersistence
{
    
    public Guid IdClient { get; set; }
    public ClientPersistence Client { get; set; }
    
    public Guid IdService { get; set; }
    public ServicesPersistence Service { get; set; }
    public string? Comments { get; set; }
    public float Rating { get; set; }
    public DateTime Created { get; set; }
    public DateTime Updated { get; set; }
}