namespace APIAeropuerto.Application.DTOs.Repair;

public class UpdateRepairDTO
{
    public Guid Id { get; set; }
    public int Rating { get; set; }
    public string Comment { get; set; }
    public DateTime DateInit { get; set; }
    public DateTime DateEnd { get; set; }
    public DateTime DateEstimated { get; set; }
}