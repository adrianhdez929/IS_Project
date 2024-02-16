using APIAeropuerto.Application.DTOs.Client;
using APIAeropuerto.Domain.Entities;
using APIAeropuerto.Domain.Interfaces;
using AutoMapper;

namespace APIAeropuerto.Application.UseCases.Client;

public class DeleteClientUseCase : IUseCase<string, DeleteClientDTO>
{
    private readonly IBaseRepository<ClientEntity> _repository;

    public DeleteClientUseCase(IBaseRepository<ClientEntity> repository, IMapper mapper)
    {
        _repository = repository;
    }
    public async Task<string> Execute(DeleteClientDTO dto, CancellationToken ct = default)
    {
        await _repository.Delete(dto.Id);
        return null!;
    }
}