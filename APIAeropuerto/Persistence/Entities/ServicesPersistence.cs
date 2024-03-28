using System.Collections;
using System.ComponentModel.DataAnnotations;
using APIAeropuerto.Domain.Enums;

namespace APIAeropuerto.Persistence.Entities;

public class ServicesPersistence
{ 
    public Guid Id { get; set; }
    public string Code { get; set; }
    public string Description { get; set; }
    public float Price { get; set; }
    public DateTime Created { get; set; }
    public DateTime Updated { get; set; }
    public ServiceType ServiceType { get; set; }
    public virtual InstallationsPersistence Installation { get; set; }
    public virtual IEnumerable<RepairPersistence> Repairs { get; set; }
    public virtual IEnumerable<ServiceServicePersistence> ServiceService { get; set; }
    public virtual IEnumerable<ClientServicesPersistence> ClientServices { get; set; }
}