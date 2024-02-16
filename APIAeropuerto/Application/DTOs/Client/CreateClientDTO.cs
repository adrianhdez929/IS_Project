using APIAeropuerto.Domain.Enums;

namespace APIAeropuerto.Application.DTOs.Client;

public class CreateClientDTO
{
    public string Name { get; set; }
    public string Nationality { get; set; }
    public ClientType Type { get; set; }
}