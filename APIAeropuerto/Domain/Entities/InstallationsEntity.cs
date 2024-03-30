using APIAeropuerto.Domain.Enums;
using APIAeropuerto.Domain.Shared;

namespace APIAeropuerto.Domain.Entities;

public class InstallationsEntity : BaseEntity
{
    public InstallationsEntity()
    {
        
    }
    private InstallationsEntity(Guid id ,string name, string description, string location, AirportEntity airport)
    {
        Id = id;
        Name = name;
        Description = description;
        Location = location;
        Airport = airport;
        Created = DateTime.Now;
        Updated = DateTime.Now;
    }
    private InstallationsEntity(Guid id,string name, string description, string location,InstallationTypeEntity installationTypeEntity)
    {
        Id = id;
        Name = name;
        Description = description;
        Location = location;
        InstallationType = installationTypeEntity;
        Created = DateTime.Now;
        Updated = DateTime.Now;
    }
    
    public static InstallationsWrapper Create(string name, string description, string location, AirportEntity airport)
    {
        var entity = new InstallationsEntity(Guid.NewGuid(),name, description, location, airport);
        return new InstallationsWrapper
        {
            IsSuccess = true,
            Value = entity,
            ErrorMessage = string.Empty
        };
    }
    public static InstallationsWrapper Create(string name, string description, string location,InstallationTypeEntity installationType)
    {
        var entity = new InstallationsEntity(Guid.NewGuid(),name, description, location,installationType);
        return new InstallationsWrapper
        {
            IsSuccess = true,
            Value = entity,
            ErrorMessage = string.Empty
        };
    }

    public void Update(string name, string description, string location,AirportEntity airport,InstallationTypeEntity installation)
    {
        Name = name;
        Description = description;
        Location = location;
        Airport = airport;
        InstallationType = installation;
        Updated = DateTime.Now;
    }

    public string? Name { get; set; }
    public string? Description { get; set; }
    public string Location { get; set; }
    public virtual AirportEntity Airport { get; set; }
    public virtual InstallationTypeEntity InstallationType { get; set; }
    public virtual IEnumerable<ServicesEntity> Services { get; set; }
}