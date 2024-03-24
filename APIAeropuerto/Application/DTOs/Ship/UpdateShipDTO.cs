namespace APIAeropuerto.Application.DTOs.Ship;

public class UpdateShipDTO
{
    public Guid Id { get; set; }
    public string Clasification { get; set; }
    public int PassengersAmmount { get; set; }
    public int TripulationAmmount { get; set; }
    public int Capacity { get; set; }
}