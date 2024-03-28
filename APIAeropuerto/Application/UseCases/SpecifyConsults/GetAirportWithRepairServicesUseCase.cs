using APIAeropuerto.Application.DTOs.SpecifyConsults;
using APIAeropuerto.Domain.Interfaces;

namespace APIAeropuerto.Application.UseCases.SpecifyConsults;

public class GetAirportWithRepairServicesUseCase
{
    private readonly ISpecifyConsultsRepository _specifyConsultsRepository;
    
    public GetAirportWithRepairServicesUseCase(ISpecifyConsultsRepository specifyConsultsRepository)
    {
        _specifyConsultsRepository = specifyConsultsRepository;
    }
    
    public async Task<IEnumerable<GetAirportWithRepairServicesDTO>> Execute()
    {
        return await _specifyConsultsRepository.GetAirportWithRepairServices();
    }
}