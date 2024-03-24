using APIAeropuerto.Application.DTOs.Client;
using APIAeropuerto.Application.DTOs.Services;
using APIAeropuerto.Domain.Entities;
using APIAeropuerto.Domain.Interfaces;

namespace APIAeropuerto.Application.UseCases.Client;

public class AddServiceUseCase : IUseCase<string,AddServiceDTO>
{
    private readonly IClientRepository _repository;
    private readonly IBaseRepository<ClientServicesEntity> _clientServicesRepository;
    private readonly IServiceRepository _serviceRepository;

    public AddServiceUseCase(IClientRepository repository, IBaseRepository<ClientServicesEntity> clientServicesRepository, IServiceRepository serviceRepository)
    {
        _repository = repository;
        _clientServicesRepository = clientServicesRepository;
        _serviceRepository = serviceRepository;
    }

    public async Task<string> Execute(AddServiceDTO dto, CancellationToken ct = default)
    {
        var temp = ClientServicesEntity.Create(dto.IdClient, dto.IdService, dto.Comments, dto.Rating);
        await _repository.AddService(temp.Value,ct);
        return "Service added";
    }
}