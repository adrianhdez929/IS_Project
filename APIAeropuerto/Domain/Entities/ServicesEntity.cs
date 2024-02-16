using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using APIAeropuerto.Domain.Shared;

namespace APIAeropuerto.Domain.Entities;

public class ServicesEntity
{
    public ServicesEntity()
    {
        
    }
    public ServicesEntity(string code, string description, int price,InstallationsEntity installation)
    {
        Code = code;
        Description = description;
        Price = price;
        Installation = installation;
        Created = DateTime.Now;
        Updated = DateTime.Now;
    }

    public static ServicesWrapper Create(string code, string description, int price, InstallationsEntity installation)
    {
        var service = new ServicesEntity(code, description, price, installation);
        return new ServicesWrapper()
        {
            IsSuccess = true,
            Value = service,
            ErrorMessage = string.Empty
        };
    }

    public void Update(string description,int price)
    {
        Description = description;
        Price = price;
        Updated = DateTime.UtcNow;
    }
    [Key]
    public string Code { get; set; }
    public string Description { get; set; }
    public int Price { get; set; }
    public DateTime Created { get; set; }
    public DateTime Updated { get; set; }
    public virtual InstallationsEntity Installation { get;set; }
    public virtual IEnumerable<ClientServicesEntity> ClientServices { get; set; }
}