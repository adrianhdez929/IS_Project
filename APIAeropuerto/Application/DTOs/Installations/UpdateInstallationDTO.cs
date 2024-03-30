﻿using APIAeropuerto.Domain.Enums;

namespace APIAeropuerto.Application.DTOs.Installations;

public class UpdateInstallationDTO
{
     public Guid Id { get; set; }
     public string? Name { get; set; }
     public string? Description { get; set; }
     public string? Location { get; set; }
     public Guid IdInstallationType { get; set; }
     public Guid IdAirport { get; set; }
}