namespace APIAeropuerto.Persistence.Entities;

public class ServiceServicePersistence
{
    public Guid IdService1 { get; set; }
    public virtual ServicesPersistence RepairService1 { get; set; }
    public Guid IdService2 { get; set; }
    public virtual ServicesPersistence RepairService2 { get; set; }
}