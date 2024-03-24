namespace APIAeropuerto.Domain.Entities;

public class ServiceServiceEntity : BaseEntity
{
    public Guid IdService1 { get; set; }
    public virtual ServicesEntity RepairService1 { get; set; }
    public Guid IdService2 { get; set; }
    public virtual ServicesEntity RepairService2 { get; set; }
    
    public ServiceServiceEntity(Guid idService1, Guid idService2)
    {
        IdService1 = idService1;
        IdService2 = idService2;
    }
    
    public static ServiceServiceEntity Create(Guid idService1, Guid idService2)
    {
        return new ServiceServiceEntity(idService1, idService2);
    }
}