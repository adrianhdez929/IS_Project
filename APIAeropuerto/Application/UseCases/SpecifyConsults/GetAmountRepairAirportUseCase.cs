using APIAeropuerto.Application.DTOs.SpecifyConsults;
using APIAeropuerto.Domain.Interfaces;

namespace APIAeropuerto.Application.UseCases.SpecifyConsults;

public class GetAmountRepairAirportUseCase
{
    private readonly ISpecifyConsultsRepository _specifyConsultsRepository;
    
    public GetAmountRepairAirportUseCase(ISpecifyConsultsRepository specifyConsultsRepository)
    {
        _specifyConsultsRepository = specifyConsultsRepository;
    }
    
    public async Task<IEnumerable<GetAmountRepairAirportDTO>> Execute()
    {
        return await _specifyConsultsRepository.GetAmountRepairAirport();
    }
}