using APIAeropuerto.Application.DTOs.Installations;

namespace APIAeropuerto.Application.DTOs.Services;

public class CreateServiceDTO
{
    public string Code { get; set; }
    public string Description { get; set; }
    public int Price { get; set; }
    public Guid IdInstallation { get; set; }
}