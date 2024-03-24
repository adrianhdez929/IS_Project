﻿namespace APIAeropuerto.Application.DTOs.Installations;

public class CreateInstallationsDTO
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Type { get; set; }
    public string Location { get; set; }
    
    public Guid IdAirport { get; set; }
}