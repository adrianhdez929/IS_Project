using APIAeropuerto.Application.DTOs.Client;
using APIAeropuerto.Application.DTOs.Services;
using APIAeropuerto.Domain.Entities;
using APIAeropuerto.Domain.Enums;
using APIAeropuerto.Domain.Interfaces;
using APIAeropuerto.Persistence.Entities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Exception = System.Exception;

namespace APIAeropuerto.Persistence.Repositories;

public class ServiceRepository : BaseRepository<ServicesEntity,ServicesPersistence,CoreDbContext> , IServiceRepository
{
    public ServiceRepository(CoreDbContext context, IMapper mapper) : base(context, mapper)
    {
    }

    public async Task<ServiceDTO> CreateRepairService(CreateRepairServiceDTO dto, CancellationToken ct)
    {
        var i = await _context
            .Installations
            .Include(x => x.Services)
            .FirstOrDefaultAsync(x => x.Id == dto.InstallationId, ct);
        
        if (i is null) throw new Exception("Installation not Found");
        var service = ServicesEntity.CreateRepairService(dto.Code, dto.Description, dto.Price, _mapper.Map<InstallationsEntity>(i), ServiceType.Repair);
        if (!service.IsSuccess) throw new Exception(service.ErrorMessage);
        var all = await _context.Services.ToListAsync(ct);
        if (all.Any(x => x.Code == service.Value?.Code)) throw new Exception("Code already exists");
        service.Value!.Installation = null!;
        var mapper = _mapper.Map<ServicesPersistence>(service.Value);
        _context.Services.Add(mapper);
        var temp = i.Services?.ToList() ?? new List<ServicesPersistence>();
        temp.Add(mapper);
        i.Services = temp;
        foreach (var s in dto.RepairService)
        {
            if(!all.Any(x => x.Id == s)) throw new Exception("Service not Found");
            var serviceService = ServiceServiceEntity.Create(service.Value!.Id, s);
            _context.RepairServices.Add(_mapper.Map<ServiceServicePersistence>(serviceService));
        }
        await _context.SaveChangesAsync(ct);
        return _mapper.Map<ServiceDTO>(service.Value);
    }

    public virtual async Task<ServicesEntity> CreateService(ServicesPersistence entity, CancellationToken ct)
    {
        var i = await _context
            .Installations
            .Include(x => x.Services)
            .FirstOrDefaultAsync(x => x.Id == entity.Installation.Id, ct);
        
        if (i is null) throw new Exception("Installation not Found");
        entity.Installation = null!;
        _context.Services.Add(entity);
        var temp = i.Services?.ToList() ?? new List<ServicesPersistence>();
        temp.Add(entity);
        i.Services = temp;
        
        await _context.SaveChangesAsync(ct);
        return _mapper.Map<ServicesEntity>(entity);
    }

    public virtual async Task DeleteService(string code)
    {
        var temp = await _table.FindAsync(code);
        if (temp is null) throw new Exception("Service not Found");
        _table.Remove(temp);
        await _context.SaveChangesAsync();
    }

    public virtual async Task<ServicesEntity> GetOneService(string code)
    {
        var temp = await _table.FindAsync(code);
        if(temp is null) throw new Exception("Service not Found");
        return _mapper.Map<ServicesEntity>(temp);
    }

    public virtual async Task UpdateService(string code, ServicesEntity entity,CancellationToken ct)
    {
        if (entity is null) throw new ArgumentNullException(nameof(entity), "Service cannot be null");

        var existingEntity = await _table.FindAsync(code);
        if (existingEntity is null) throw new KeyNotFoundException($"Error: Service with code {code} Not Found");

        var updatedEntity = _mapper.Map<ServicesEntity, ServicesPersistence>(entity);
        _table.Entry(existingEntity).CurrentValues.SetValues(updatedEntity);
        _table.Entry(existingEntity).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync(ct);
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

    public async Task<GetAllClientsServiceDTO> GetAllClientsService(string code,CancellationToken ct)
    {
        var temp = await _context.Services.Include(x => x.ClientServices)
            .ThenInclude(x => x.Client)
            .FirstOrDefaultAsync(y => y.Code == code);
        var result = temp?.ClientServices.Select(x => x.Client).ToList();
        return new GetAllClientsServiceDTO()
        {
            Clients = _mapper.Map<List<ClientDTO>>(result)
        };
    }
}