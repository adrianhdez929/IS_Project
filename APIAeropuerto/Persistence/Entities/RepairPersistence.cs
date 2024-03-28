namespace APIAeropuerto.Persistence.Entities;

public class RepairPersistence
{
    public Guid Id { get; set; }
    public int Rating { get; set; }
    public string Comment { get; set; }
    public float Cost { get; set; }
    public DateTime DateInit { get; set; }
    public DateTime DateEnd { get; set; }
    public DateTime DateEstimated { get; set; }
    public Guid IdService { get; set; }
    public ServicesPersistence Service { get; set; }
    public Guid IdShip { get; set; }
    public ShipPersistence Ship { get; set; }
}