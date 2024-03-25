using APIAeropuerto.Application.DTOs.Services;
using APIAeropuerto.Domain.Entities;
using APIAeropuerto.Domain.Interfaces;
using AutoMapper;

namespace APIAeropuerto.Application.UseCases.Services;

public class UpdateServiceUseCase : IUseCase<ServiceDTO,UpdateServiceDTO>
{
    private readonly IServiceRepository _repository;
    private readonly IMapper _mapper;

    public UpdateServiceUseCase(IServiceRepository repository,IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task<ServiceDTO> Execute(UpdateServiceDTO dto, CancellationToken ct = default)
    {
        var temp = await _repository.GetOneService(dto.Id);
        temp.Update(dto.Description,dto.Precio);
        await _repository.UpdateService(dto.Id,temp, ct);
        return _mapper.Map<ServiceDTO>(temp);
    }
}