namespace APIAeropuerto.Application.DTOs.Repair;

public class RepairDTO
{
    public int Rating { get; set; }
    public string Comment { get; set; }
    public float Cost { get; set; }
    public DateTime DateInit { get; set; }
    public DateTime DateEnd { get; set; }
    public DateTime DateEstimated { get; set; }
    public Guid IdService { get; set; }
    public string Code { get; set; }
    public Guid IdShip { get; set; }
    public string Tuition { get; set; }
}