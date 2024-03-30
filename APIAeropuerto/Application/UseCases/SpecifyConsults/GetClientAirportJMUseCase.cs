using APIAeropuerto.Application.DTOs.SpecifyConsults;
using APIAeropuerto.Domain.Interfaces;

namespace APIAeropuerto.Application.UseCases.SpecifyConsults;

public class GetClientAirportJMUseCase
{
    private readonly ISpecifyConsultsRepository _specifyConsultsRepository;
    
    public GetClientAirportJMUseCase(ISpecifyConsultsRepository specifyConsultsRepository)
    {
        _specifyConsultsRepository = specifyConsultsRepository;
    }
    
    public async Task<IEnumerable<GetClientAirportJMDTO>> Execute()
    {
        return await _specifyConsultsRepository.GetClientAirportJM();
    }
}