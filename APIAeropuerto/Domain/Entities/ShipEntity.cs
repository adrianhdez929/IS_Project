using APIAeropuerto.Domain.Shared;

namespace APIAeropuerto.Domain.Entities;

public class ShipEntity : BaseEntity
{
    public string Tuition {get; set; }
    public string Clasification { get; set; }
    public int PassengersAmmount { get; set; }
    public int TripulationAmmount { get; set; }
    public int Capacity { get; set; }
    public virtual ClientEntity Propietary { get; set; }
    public virtual IEnumerable<RepairEntity> Repairs { get; set; }
    public virtual IEnumerable<FlightEntity> Flights { get; set; }

    public ShipEntity()
    {
        
    }
    public ShipEntity(Guid id,string tuition, string clasification, int passengersAmmount, 
        int tripulationAmmount, int capacity)
    {
        Id = id;
        Tuition = tuition;
        Clasification = clasification;
        PassengersAmmount = passengersAmmount;
        TripulationAmmount = tripulationAmmount;
        Capacity = capacity;
        Created = DateTime.Now;
        Updated = DateTime.Now;
    }
    
    public static ShipWrapper Create(string tuition, string clasification, int passengersAmmount, 
        int tripulationAmmount, int capacity)
    {
        var ship = new ShipEntity(Guid.NewGuid(), tuition, clasification, passengersAmmount, 
            tripulationAmmount, capacity);
        var wrapper = new ShipWrapper
        {
            IsSuccess = true,
            Value = ship
        };
        return wrapper;
    }
    
    public void Update(string clasification, int passengersAmmount, 
        int tripulationAmmount, int capacity)
    {
        Clasification = clasification;
        PassengersAmmount = passengersAmmount;
        TripulationAmmount = tripulationAmmount;
        Capacity = capacity;
        Updated = DateTime.Now;
    }
}