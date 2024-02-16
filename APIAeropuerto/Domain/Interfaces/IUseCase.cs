namespace APIAeropuerto.Domain.Interfaces;

public interface IUseCase<TDEntity, Dto>
    where TDEntity : class
    where Dto : class
{
    Task<TDEntity> Execute(Dto dto, CancellationToken ct = default);
}