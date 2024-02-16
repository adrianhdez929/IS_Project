using APIAeropuerto.Domain.Enums;

namespace APIAeropuerto.Application.DTOs.Client;

public class ClientDTO
{
    public string Name { get; set; }
    public string Nationality { get; set;}
    public ClientType Type { get; set; }
}