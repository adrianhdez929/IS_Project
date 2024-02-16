using APIAeropuerto.Domain.Shared;

namespace APIAeropuerto.Domain.Entities;

public class InstallationsEntity : BaseEntity
{
    public InstallationsEntity()
    {
        
    }
    private InstallationsEntity(Guid id ,string name, string description, string location, string type, AirportEntity airport)
    {
        Id = id;
        Name = name;
        Description = description;
        Location = location;
        Type = type;
        Airport = airport;
        Created = DateTime.Now;
        Updated = DateTime.Now;
    }
    private InstallationsEntity(Guid id,string name, string description, string location, string type)
    {
        Id = id;
        Name = name;
        Description = description;
        Location = location;
        Type = type;
        Created = DateTime.Now;
        Updated = DateTime.Now;
    }
    
    public static InstallationsWrapper Create(string name, string description, string location, string type, AirportEntity airport)
    {
        var entity = new InstallationsEntity(Guid.NewGuid(),name, description, location, type, airport);
        return new InstallationsWrapper
        {
            IsSuccess = true,
            Value = entity,
            ErrorMessage = string.Empty
        };
    }
    public static InstallationsWrapper Create(string name, string description, string location, string type)
    {
        var entity = new InstallationsEntity(Guid.NewGuid(),name, description, location, type);
        return new InstallationsWrapper
        {
            IsSuccess = true,
            Value = entity,
            ErrorMessage = string.Empty
        };
    }

    public void Update(string name, string description, string location, string type)
    {
        Name = name;
        Description = description;
        Location = location;
        Type = type;
        Updated = DateTime.Now;
    }

    public string? Name { get; set; }
    public string? Description { get; set; }
    public string Location { get; set; }
    public string Type { get; set; }
    public virtual AirportEntity Airport { get; set; }
    public virtual IEnumerable<ServicesEntity> Services { get; set; }
}