using System.Linq.Expressions;
using APIAeropuerto.Domain.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace APIAeropuerto.Persistence.Repositories;
public class BaseRepository<TEntity,TPEntity,TContext> : IBaseRepository<TEntity>
    where TEntity : class
    where TPEntity: class
    where TContext : DbContext
{
    protected readonly TContext _context;
    protected readonly DbSet<TPEntity> _table;
    protected readonly IMapper _mapper;

    public BaseRepository( TContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
        _table = context.Set<TPEntity>();
    }
    public virtual async Task<ICollection<TEntity>> GetAll(CancellationToken cancellationToken)
    {
        var temp = await _table.ToListAsync(cancellationToken);
        return temp.Select(x => _mapper.Map<TPEntity, TEntity>(x)).ToList();
    }
    public virtual async Task<TEntity> GetOne(Guid id, CancellationToken cancellationToken)
    {
        var temp = await _table.FindAsync(id);
        return _mapper.Map<TPEntity, TEntity>(temp??throw new KeyNotFoundException($"Error: Entity with ID {id} Not Found"));
    }

    public virtual async Task<TEntity> Create(TEntity entity, CancellationToken cancellationToken)
    {
        var temp = _mapper.Map<TEntity, TPEntity>(entity);
        try
        {
            await _table.AddAsync(temp);
            await _context.SaveChangesAsync(cancellationToken);
            return _mapper.Map<TPEntity, TEntity>(temp);
        }
        catch (DbUpdateException ex)
        {
            throw new InvalidOperationException("A database update exception occurred while saving data", ex);
        }
        catch (Exception ex)
        {
            throw new Exception($"An unexpected error occurred: {ex.Message}", ex);
        }
    }

    public virtual async Task Put(Guid id, TEntity entity, CancellationToken cancellationToken)
    {
        if (entity is null) throw new ArgumentNullException(nameof(entity), "Entity cannot be null");

        var existingEntity = await _table.FindAsync(id);
        if (existingEntity is null) throw new KeyNotFoundException($"Error: Entity with ID {id} Not Found");

        var updatedEntity = _mapper.Map<TEntity, TPEntity>(entity);
        _table.Entry(existingEntity).CurrentValues.SetValues(updatedEntity);
        _table.Entry(existingEntity).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync(cancellationToken);
        }
        catch (DbUpdateException ex)
        {
            throw new InvalidOperationException("A database update exception occurred while saving data", ex);
        }
        catch (Exception ex)
        {
            throw new Exception($"An unexpected error occurred: {ex.Message}", ex);
        }
    }

    public virtual async Task Delete(Guid id, CancellationToken cancellationToken)
    {
        var temp = await _table.FindAsync(id);
        if(temp is null) throw new KeyNotFoundException($"Error: Entity with ID {id} Not Found");
        _table.Remove(temp);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<TEntity> GetOneReadOnlyAsync<TKey>(TKey primaryKeyValue, string primaryKeyName = "Id", CancellationToken cancellationToken = default)
    {
        var parameter = Expression.Parameter(typeof(TPEntity), "entity");
        var property = Expression.Property(parameter, primaryKeyName);
        var value = Expression.Constant(primaryKeyValue);
        var equal = Expression.Equal(property, value);
        var lambda = Expression.Lambda<Func<TPEntity, bool>>(equal, parameter);
        
        var temp = await _table
            .AsNoTracking()
            .FirstOrDefaultAsync(lambda, cancellationToken);

        if (temp == null)
        {
            throw new KeyNotFoundException($"Error: Entity with {primaryKeyName} {primaryKeyValue} Not Found");
        }

        return _mapper.Map<TPEntity, TEntity>(temp);
    }

}