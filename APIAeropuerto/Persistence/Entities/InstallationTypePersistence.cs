namespace APIAeropuerto.Persistence.Entities;

public class InstallationTypePersistence
{
    public Guid Id { get; set; }
    public string Type { get; set; }
    public virtual IEnumerable<InstallationsPersistence> Installations { get; set; }
}