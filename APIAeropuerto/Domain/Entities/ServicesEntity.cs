using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using APIAeropuerto.Domain.Enums;
using APIAeropuerto.Domain.Shared;
using APIAeropuerto.Persistence.Entities;

namespace APIAeropuerto.Domain.Entities;

public class ServicesEntity : BaseEntity
{
    public ServicesEntity()
    {
        
    }
    public ServicesEntity(Guid id,string code, string description, float price,InstallationsEntity installation,ServiceType serviceType)
    {
        Id = id;
        Code = code;
        Description = description;
        Price = price;
        Installation = installation;
        ServiceType = serviceType;
        Created = DateTime.Now;
        Updated = DateTime.Now;
    }

    public static ServicesWrapper Create(string code, string description, float price, InstallationsEntity installation,ServiceType serviceType)
    {
        if(code.Length != 4)
        {
            return new ServicesWrapper()
            {
                IsSuccess = false,
                Value = null,
                ErrorMessage = "El código debe tener 4 caracteres"
            };
        }
        if(price <= 0)
        {
            return new ServicesWrapper()
            {
                IsSuccess = false,
                Value = null,
                ErrorMessage = "El precio debe ser mayor a 0"
            };
        }
        if(serviceType == ServiceType.Repair)
        {
            return new ServicesWrapper()
            {
                IsSuccess = false,
                Value = null,
                ErrorMessage = "No se puede crear un servicio de reparación, utilice el servicio de crear servicio de reparación"
            };
        }
        var service = new ServicesEntity(Guid.NewGuid(),code, description, price, installation,serviceType);
        return new ServicesWrapper()
        {
            IsSuccess = true,
            Value = service,
            ErrorMessage = string.Empty
        };
    }
    public static ServicesWrapper CreateRepairService(string code, string description, float price, InstallationsEntity installation,ServiceType serviceType,List<ServicesPersistence> servicesToAdd)
    {
        if(code.Length != 4)
        {
            return new ServicesWrapper()
            {
                IsSuccess = false,
                Value = null,
                ErrorMessage = "El código debe tener 4 caracteres"
            };
        }
        if(price < 0)
        {
            return new ServicesWrapper()
            {
                IsSuccess = false,
                Value = null,
                ErrorMessage = "El precio debe ser mayor a 0"
            };
        }
        if(price == 0 && servicesToAdd.Count == 0)
        {
            return new ServicesWrapper()
            {
                IsSuccess = false,
                Value = null,
                ErrorMessage = "El precio debe ser mayor a 0"
            };
        }

        foreach (var s in servicesToAdd)
            price += s.Price;
        var service = new ServicesEntity(Guid.NewGuid(),code, description, price, installation,serviceType);
        return new ServicesWrapper()
        {
            IsSuccess = true,
            Value = service,
            ErrorMessage = string.Empty
        };
    }

    public void Update(string description,float price)
    {
        Description = description;
        Price = price;
        Updated = DateTime.UtcNow;
    }
    [Key]
    public string Code { get; set; }
    public string Description { get; set; }
    public float Price { get; set; }
    public ServiceType  ServiceType { get; set; }
    public virtual InstallationsEntity Installation { get;set; }
    public virtual IEnumerable<RepairEntity> Repairs { get; set; }
    public virtual IEnumerable<ServiceServiceEntity> ServiceServices { get; set; }
    public virtual IEnumerable<ClientServicesEntity> ClientServices { get; set; }
}