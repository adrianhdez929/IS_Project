namespace APIAeropuerto.Application.DTOs.Client;

public class AddServiceDTO
{
    public Guid IdClient { get; set; }
    public Guid IdService { get; set; }
    public string Comments { get; set; }
    public float Rating { get; set; }
}