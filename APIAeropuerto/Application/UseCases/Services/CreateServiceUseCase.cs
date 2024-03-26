using APIAeropuerto.Application.DTOs.Services;
using APIAeropuerto.Application.Exceptions.BadRequest;
using APIAeropuerto.Application.Exceptions.NotFound;
using APIAeropuerto.Domain.Entities;
using APIAeropuerto.Domain.Interfaces;
using APIAeropuerto.Persistence.Entities;
using AutoMapper;

namespace APIAeropuerto.Application.UseCases.Services;

public class CreateServiceUseCase : IUseCase<ServiceDTO,CreateServiceDTO>
{
    private readonly IInstallationRepository _installationRepository;
    private readonly IServiceRepository _repository;
    private readonly IBaseRepository<ServicesEntity> _baseRepository;
    private readonly IMapper _mapper;

    public CreateServiceUseCase(IInstallationRepository installationRepository,IServiceRepository repository,IBaseRepository<ServicesEntity> baseRepository,IMapper mapper)
    {
        _installationRepository = installationRepository;
        _repository = repository;
        _baseRepository = baseRepository;
        _mapper = mapper;
    }
    public async Task<ServiceDTO> Execute(CreateServiceDTO dto, CancellationToken ct = default)
    {
        var i = await _installationRepository.GetOneInstallation(dto.IdInstallation, ct);
        if (i == null) throw new NotFoundException("Installation not found");
        var s = ServicesEntity.Create(dto.Code, dto.Description, dto.Price, i, dto.ServiceType);
        if (!s.IsSuccess) throw new ServiceBadRequestException(s.ErrorMessage!);
        var all = await _baseRepository.GetAll();
        if (all.Any(x => x.Code == s.Value?.Code)) throw new RepeatBadRequestException("Code already exists");
        await _repository.CreateService(_mapper.Map<ServicesPersistence>(s.Value), ct);
        return _mapper.Map<ServiceDTO>(dto);
    }
}