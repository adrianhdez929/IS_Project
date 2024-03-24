using APIAeropuerto.Domain.Shared;

namespace APIAeropuerto.Domain.Entities;

public class ClientServicesEntity
{
    public ClientServicesEntity()
    {
        
    }

    public ClientServicesEntity(Guid idClient, Guid idService, string comments, float rating)
    {
        IdClient = idClient;
        IdService = idService;
        Comments = comments;
        Rating = rating;
        Created = DateTime.Now;
        Updated = DateTime.Now;
    }
    public static ClientServicesWrapper Create(Guid idClient, Guid idService, string comments, float rating)
    {
        if(rating < 0 || rating > 10) return new ClientServicesWrapper()
        {
            Value = null,
            ErrorMessage = "Rating must be between 0 and 10",
            IsSuccess = false
        };
        var temp = new ClientServicesEntity(idClient, idService, comments, rating);
        return new ClientServicesWrapper()
        {
            Value = temp,
            ErrorMessage = string.Empty,
            IsSuccess = true
        };
    }
    public Guid IdClient { get; set; }
    public ClientEntity Client { get; set; }
    public Guid IdService { get; set; }
    public ServicesEntity Service { get; set; }
    public string? Comments { get; set; }
    public float Rating { get; set; }
    public DateTime Created { get; set; }
    public DateTime Updated { get; set; }
}