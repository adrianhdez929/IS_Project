using APIAeropuerto.Application.DTOs.SpecifyConsults;
using APIAeropuerto.Domain.Interfaces;

namespace APIAeropuerto.Application.UseCases.SpecifyConsults;

public class GetAvgServicesPriceJMUseCase
{
    private readonly ISpecifyConsultsRepository _specifyConsultsRepository;
    
    public GetAvgServicesPriceJMUseCase(ISpecifyConsultsRepository specifyConsultsRepository)
    {
        _specifyConsultsRepository = specifyConsultsRepository;
    }
    
    public async Task<IEnumerable<GetAvgServicesPriceJMDTO>> Execute()
    {
        return await _specifyConsultsRepository.GetAvgServicesPriceJM();
    }
}