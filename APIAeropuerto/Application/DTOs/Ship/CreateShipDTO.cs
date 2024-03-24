namespace APIAeropuerto.Application.DTOs.Ship;

public class CreateShipDTO
{
    public string Tuition { get; set; }
    public string Clasification { get; set; }
    public int PassengersAmmount { get; set; }
    public int TripulationAmmount { get; set; }
    public int Capacity { get; set; }
    public Guid PropietaryId { get; set; }
}