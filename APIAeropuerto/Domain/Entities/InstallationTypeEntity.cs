namespace APIAeropuerto.Domain.Entities;

public class InstallationTypeEntity : BaseTypeEntity
{
    public virtual IEnumerable<InstallationsEntity> Installations { get; set; }

    public static InstallationTypeEntity Create(string type)
    {
        return new InstallationTypeEntity
        {
            Id = Guid.NewGuid(),
            Type = type
        };
    }
}