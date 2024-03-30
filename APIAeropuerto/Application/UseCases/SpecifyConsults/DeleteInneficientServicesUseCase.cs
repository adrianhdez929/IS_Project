using APIAeropuerto.Application.DTOs.SpecifyConsults;
using APIAeropuerto.Domain.Interfaces;

namespace APIAeropuerto.Application.UseCases.SpecifyConsults;

public class DeleteInneficientServicesUseCase
{
    private readonly ISpecifyConsultsRepository _specifyConsultsRepository;
    
    public DeleteInneficientServicesUseCase(ISpecifyConsultsRepository specifyConsultsRepository)
    {
        _specifyConsultsRepository = specifyConsultsRepository;
    }
    
    public async Task<string> Execute(DeleteInneficientServicesDTO dto)
    {
        return await _specifyConsultsRepository.DeleteInneficientServices(dto);
    }
}