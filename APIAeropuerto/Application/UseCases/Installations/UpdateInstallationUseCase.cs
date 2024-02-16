﻿using APIAeropuerto.Application.DTOs.Installations;
using APIAeropuerto.Domain.Entities;
using APIAeropuerto.Domain.Interfaces;
using AutoMapper;

namespace APIAeropuerto.Application.UseCases.Installations;

public class UpdateInstallationUseCase : IUseCase<InstallationDTO,UpdateInstallationDTO>
{
    private readonly IInstallationRepository _repository;
    private readonly IMapper _mapper;

    public UpdateInstallationUseCase(IInstallationRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task<InstallationDTO> Execute(UpdateInstallationDTO dto, CancellationToken ct = default)
    {
        var temp = await _repository.GetOneInstallation(dto.Id,ct);
        temp.Update(dto.Name, dto.Description,dto.Location, dto.Type);
        await _repository.Put(temp.Id, temp);
        return _mapper.Map<InstallationDTO>(temp);
    }
}