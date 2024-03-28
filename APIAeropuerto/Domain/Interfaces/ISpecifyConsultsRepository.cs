using APIAeropuerto.Application.DTOs.SpecifyConsults;

namespace APIAeropuerto.Domain.Interfaces;

public interface ISpecifyConsultsRepository
{
    Task<IEnumerable<GetAirportWithRepairServicesDTO>> GetAirportWithRepairServices();
    Task<IEnumerable<GetAmountRepairAirportDTO>> GetAmountRepairAirport();
    Task<IEnumerable<GetClientAirportJMDTO>> GetClientAirportJM();
    Task<string> DeleteInneficientServices();
}