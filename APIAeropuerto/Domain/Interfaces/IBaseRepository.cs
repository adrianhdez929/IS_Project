namespace APIAeropuerto.Domain.Interfaces;
public interface IBaseRepository<TEntity>
{
    Task<ICollection<TEntity>> GetAll(CancellationToken cancellationToken = default);
    Task<TEntity> GetOne(Guid id, CancellationToken cancellationToken = default);
    Task<TEntity> Create(TEntity entity, CancellationToken cancellationToken = default);
    Task Put(Guid id, TEntity entity, CancellationToken cancellationToken = default);
    Task Delete(Guid id, CancellationToken cancellationToken = default);
}