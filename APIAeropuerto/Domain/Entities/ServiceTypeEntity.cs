namespace APIAeropuerto.Domain.Entities;

public class ServiceTypeEntity : BaseTypeEntity
{
    public virtual IEnumerable<ServicesEntity> Services { get; set; }

    public static ServiceTypeEntity Create(string type)
    {
        return new ServiceTypeEntity
        {
            Id = Guid.NewGuid(),
            Type = type
        };
    }
}