using APIAeropuerto.Domain.Entities;
using APIAeropuerto.Domain.Interfaces;

namespace APIAeropuerto.Domain.Shared;

public class AirportWrapper: ISimpleWrapper<AirportEntity>
{
    public bool IsSuccess { get; set; }
    public AirportEntity Value { get; set; }
    public string ErrorMessage { get; set; }
}