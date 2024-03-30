using APIAeropuerto.Application.DTOs.Client;
using APIAeropuerto.Application.DTOs.Services;
using APIAeropuerto.Application.Exceptions.BadRequest;
using APIAeropuerto.Application.Exceptions.NotFound;
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
        
        if (i is null) throw new NotFoundException("Installation not Found");
        var all = await _context.Services.ToListAsync(ct);
        if (all.Any(x => x.Code == dto.Code)) throw new RepeatBadRequestException("Code already exists");
        var servicesToAdd = all.Where(x => dto.RepairService.Contains(x.Id)).ToList();
        var st = await _context.ServiceTypes.FirstOrDefaultAsync(x => x.Type == "Repair", ct);
        if (st is null) throw new NotFoundException("Service Type not Found");
        var service = ServicesEntity.CreateRepairService(dto.Code, dto.Description, dto.Price, _mapper.Map<InstallationsEntity>(i), st.Type,servicesToAdd);
        if (!service.IsSuccess) throw new ServiceBadRequestException(service.ErrorMessage!);
        service.Value!.Installation = null!;
        var mapper = _mapper.Map<ServicesPersistence>(service.Value);
        _context.Services.Add(mapper);
        var temp = i.Services?.ToList() ?? new List<ServicesPersistence>();
        var temp1 = st!.Services?.ToList() ?? new List<ServicesPersistence>();
        temp.Add(mapper);
        temp1.Add(mapper);
        i.Services = temp;
        st.Services = temp1;
        foreach (var s in dto.RepairService)
        {
            if(!all.Any(x => x.Id == s)) throw new NotFoundException("Service not Found");
            var serviceService = ServiceServiceEntity.Create(service.Value!.Id, s);
            _context.RepairServices.Add(_mapper.Map<ServiceServicePersistence>(serviceService));
        }
        await _context.SaveChangesAsync(ct);
        service.Value!.ServiceTypeEntity = _mapper.Map<ServiceTypeEntity>(st);
        service.Value!.Installation = _mapper.Map<InstallationsEntity>(i);
        return _mapper.Map<ServiceDTO>(service.Value);
    }

    public virtual async Task<ServicesEntity> CreateService(ServicesPersistence entity, CancellationToken ct)
    {
        var i = await _context
            .Installations
            .Include(x => x.Services)
            .FirstOrDefaultAsync(x => x.Id == entity.Installation.Id, ct);
        var st = await _context.ServiceTypes.FirstOrDefaultAsync(x => x.Id == entity.ServiceType.Id, ct);
        
        if (i is null) throw new NotFoundException("Installation not Found");
        entity.Installation = null!;
        entity.ServiceType = null!;
        _context.Services.Add(entity);
        var temp = i.Services?.ToList() ?? new List<ServicesPersistence>();
        var temp1 = st!.Services?.ToList() ?? new List<ServicesPersistence>();
        temp1.Add(entity);
        temp.Add(entity);
        i.Services = temp;
        st.Services = temp1;
        
        await _context.SaveChangesAsync(ct);
        return _mapper.Map<ServicesEntity>(entity);
    }

    public virtual async Task DeleteService(Guid id)
    {
        var temp = await _table.FindAsync(id);
        if (temp is null) throw new NotFoundException("Service not Found");
        _table.Remove(temp);
        await _context.SaveChangesAsync();
    }

    public virtual async Task<ServicesEntity> GetOneService(Guid id)
    {
        var temp = await _table.Include(x => x.ServiceType)
            .Include(x => x.Installation)
            .FirstOrDefaultAsync(x => x.Id == id);
        if(temp is null) throw new NotFoundException("Service not Found");
        return _mapper.Map<ServicesEntity>(temp);
    }

    public virtual async Task UpdateService(Guid id, ServicesEntity entity,CancellationToken ct)
    {
        if (entity is null) throw new ArgumentNullException(nameof(entity), "Service cannot be null");

        var existingEntity = await _table.Include(x => x.ServiceType)
            .Include(x => x.Installation)
            .FirstOrDefaultAsync(x => x.Id == id, ct);
        if (existingEntity is null) throw new NotFoundException($"Error: Service with id {id} Not Found");

        var updatedEntity = _mapper.Map<ServicesEntity, ServicesPersistence>(entity);
        updatedEntity.Id = id;
        _context.Entry(existingEntity).CurrentValues.SetValues(updatedEntity);
        if(existingEntity.ServiceType.Id != updatedEntity.ServiceType.Id)
            existingEntity.ServiceType = updatedEntity.ServiceType;
        if(existingEntity.Installation.Id != updatedEntity.Installation.Id)
            existingEntity.Installation = updatedEntity.Installation;
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

    public async Task<GetAllClientsServiceDTO> GetAllClientsService(Guid id,CancellationToken ct)
    {
        var temp = await _context.Services.Include(x => x.ClientServices)
            .ThenInclude(x => x.Client)
            .FirstOrDefaultAsync(y => y.Id == id);
        var result = temp?.ClientServices.Select(x => x.Client).ToList();
        return new GetAllClientsServiceDTO()
        {
            Clients = _mapper.Map<List<GetAllClientDTO>>(result)
        };
    }

    public async Task<IEnumerable<GetAllServicesDTO>> GetAllServices(CancellationToken ct)
    {
        var result = await _table.Include(x => x.Installation)
            .Include(x => x.ServiceType)
            .ToListAsync();

        return _mapper.Map<IEnumerable<GetAllServicesDTO>>(result);
    }

    public async Task<IEnumerable<GetAllServicesDTO>> GetAllRepairServices(CancellationToken ct = default)
    {
        var services = await _table.Include(x => x.ServiceType)
            .Include(x => x.Installation)
            .ToListAsync();
        var result = services.Where(x => x.ServiceType.Type == "Repair");
        return _mapper.Map<IEnumerable<GetAllServicesDTO>>(result);
    }
}