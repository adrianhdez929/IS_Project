namespace APIAeropuerto.Persistence.Entities;

public class ShipPersistence
{
    public Guid Id { get; set; }
    public string Tuition {get; set; }
    public string Clasification { get; set; }
    public int PassengersAmmount { get; set; }
    public int TripulationAmmount { get; set; }
    public int Capacity { get; set; }
    public DateTime Created { get; set; }
    public DateTime Updated { get; set; }
    public virtual ClientPersistence Propietary { get; set; }
    public virtual IEnumerable<FlightPersistence> Flights { get; set; }
}