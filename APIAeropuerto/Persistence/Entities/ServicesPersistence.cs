using System.ComponentModel.DataAnnotations;

namespace APIAeropuerto.Persistence.Entities;

public class ServicesPersistence
{
    [Key]
    public string Code { get; set; }
    public string Description { get; set; }
    public int Precio { get; set; }
    public DateTime Created { get; set; }
    public DateTime Updated { get; set; }
    public virtual InstallationsPersistence Installation { get; set; }
    public virtual IEnumerable<ClientServicesPersistence> ClientServices { get; set; }
}