namespace APIAeropuerto.Application.DTOs.Repair;

public class CreateRepairDTO
{
    public int Rating { get; set; }
    public string Comment { get; set; }
    public DateTime DateInit { get; set; }
    public DateTime DateEnd { get; set; }
    public DateTime DateEstimated { get; set; }
    public Guid IdService { get; set; }
    public Guid IdShip { get; set; }
}