using APIAeropuerto.Application.DTOs.SpecifyConsults;
using APIAeropuerto.Application.UseCases.Installations;
using APIAeropuerto.Domain.Interfaces;
using APIAeropuerto.Persistence.Entities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace APIAeropuerto.Persistence.Repositories;

public class SpecifyConsultsRepository : ISpecifyConsultsRepository
{
    private readonly CoreDbContext _context;
    private readonly IInstallationRepository _installationRepository;
    private readonly IMapper _mapper;
    
    public SpecifyConsultsRepository(CoreDbContext context, 
        IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    
    public async Task<IEnumerable<GetAirportWithRepairServicesDTO>> GetAirportWithRepairServices()
    {
        var airports = await _context.Airports.Include(x => x.Installations)
            .ThenInclude(x => x.Services)
            .Where(x => x.Installations.Any(y => y.Services.Any(z => z.ServiceType == 0)))
            .ToListAsync();
        
        return _mapper.Map<IEnumerable<GetAirportWithRepairServicesDTO>>(airports);
    }

    public async Task<IEnumerable<GetAmountRepairAirportDTO>> GetAmountRepairAirport()
    {
        var aux = new Dictionary<string, int>();
        var installations = await _context.Installations.Include(x => x.Services)
            .Include(x => x.Airport)
            .Where(x =>x.Services.Any(z => z.ServiceType == 0))
            .ToListAsync();
        foreach (var installation in installations)
        {
            foreach (var service in installation.Services)
            {
                var amountRepair = _context.Repairs.Where(x => x.IdService == service.Id).Count();
                if (aux.ContainsKey(installation.Airport.Name))
                {
                    aux[installation.Airport.Name] += amountRepair;
                }
                else
                {
                    aux.Add(installation.Airport.Name, amountRepair);
                }
            }
        }
        
        var result = new List<GetAmountRepairAirportDTO>();
        foreach (var (key, value) in aux)
        {
            result.Add(new GetAmountRepairAirportDTO()
            {
                NameAirport = key,
                AmountRepair = value
            });
        }
        
        return result;
    }

    public Task<IEnumerable<GetClientAirportJMDTO>> GetClientAirportJM()
    {
        throw new NotImplementedException();
    }

    public Task<string> DeleteInneficientServices()
    {
        throw new NotImplementedException();
    }
}