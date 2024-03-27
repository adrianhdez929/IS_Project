using APIAeropuerto.Application.DTOs.Services;
using APIAeropuerto.Application.Exceptions.NotFound;
using APIAeropuerto.Domain.Interfaces;
using AutoMapper;

namespace APIAeropuerto.Application.UseCases.Services;

public class GetAllClientsServiceUseCase : IUseCase<GetAllClientsServiceDTO,GetOneServiceDTO>
{
    private readonly IServiceRepository _repository;
    
    public GetAllClientsServiceUseCase(IServiceRepository repository)
    {
        _repository = repository;
    }
    public async Task<GetAllClientsServiceDTO> Execute(GetOneServiceDTO dto, CancellationToken ct = default)
    {
        var temp = await _repository.GetAllClientsService(dto.Id,ct);
        if (temp == null) throw new NotFoundException("Service not Found");
        return temp;
    }
}