using APIAeropuerto.Application.DTOs.Client;

namespace APIAeropuerto.Application.DTOs.Ship;

public class ShipDTO
{
    public string Clasification { get; set; }
    public int PassengersAmmount { get; set; }
    public int TripulationAmmount { get; set; }
    public int Capacity { get; set; }
    public string PropietaryName { get; set; }
}