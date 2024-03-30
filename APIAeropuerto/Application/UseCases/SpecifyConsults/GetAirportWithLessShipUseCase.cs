using APIAeropuerto.Application.DTOs.SpecifyConsults;
using APIAeropuerto.Domain.Interfaces;

namespace APIAeropuerto.Application.UseCases.SpecifyConsults;

public class GetAirportWithLessShipUseCase
{
    private readonly ISpecifyConsultsRepository _specifyConsultsRepository;
    
    public GetAirportWithLessShipUseCase(ISpecifyConsultsRepository specifyConsultsRepository)
    {
        _specifyConsultsRepository = specifyConsultsRepository;
    }
    
    public async Task<IEnumerable<GetAirportWithLessShipDTO>> Execute()
    {
        return await _specifyConsultsRepository.GetAirportWithLessShip();
    }
}