namespace APIAeropuerto.Application.DTOs.Services;

public class UpdateServiceDTO
{
    public Guid Id { get; set; }
    public string Code { get; set; }
    public string Description { get; set; }
    public int Precio { get; set; }
}