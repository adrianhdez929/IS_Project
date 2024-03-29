using APIAeropuerto.Application.DTOs.InstallationType;
using APIAeropuerto.Domain.Entities;
using APIAeropuerto.Domain.Interfaces;
using AutoMapper;

namespace APIAeropuerto.Application.UseCases.InstallationType;

public class GetAllInstallationTypeUseCase
{
    private readonly IBaseRepository<InstallationTypeEntity> _repository;
    private readonly IMapper _mapper;
    
    public GetAllInstallationTypeUseCase(IBaseRepository<InstallationTypeEntity> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task<IEnumerable<GetAllInstallationTypeDTO>> Execute( )
    {
        var result = await _repository.GetAll();
        return _mapper.Map<IEnumerable<GetAllInstallationTypeDTO>>(result);
    }
}