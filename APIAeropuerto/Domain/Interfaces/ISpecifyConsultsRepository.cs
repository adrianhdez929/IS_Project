﻿using APIAeropuerto.Application.DTOs.SpecifyConsults;

namespace APIAeropuerto.Domain.Interfaces;

public interface ISpecifyConsultsRepository
{
    Task<IEnumerable<GetAirportWithRepairServicesDTO>> GetAirportWithRepairServices();
    Task<IEnumerable<GetAmountRepairAirportDTO>> GetAmountRepairAirport();
    Task<IEnumerable<GetClientAirportJMDTO>> GetClientAirportJM();
    Task<IEnumerable<GetAirportWithLessShipDTO>> GetAirportWithLessShip();
    Task<IEnumerable<GetAvgServicesPriceJMDTO>> GetAvgServicesPriceJM();
    Task<string> DeleteInneficientServices(DeleteInneficientServicesDTO dto);
}