using APIAeropuerto.Application.DTOs.SpecifyConsults;
using APIAeropuerto.Application.UseCases.Installations;
using APIAeropuerto.Domain.Enums;
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
            .Where(x => x.Installations.Any(y => y.Services.Any(z => z.ServiceType.Type == "Repair")))
            .ToListAsync();
        
        return _mapper.Map<IEnumerable<GetAirportWithRepairServicesDTO>>(airports);
    }

    public async Task<IEnumerable<GetAmountRepairAirportDTO>> GetAmountRepairAirport()
    {
        var aux = new Dictionary<string, int>();
        var installations = await _context.Installations.Include(x => x.Services)
            .Include(x => x.Airport)
            .Where(x =>x.Services.Any(z => z.ServiceType.Type == "Repair"))
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

    public async Task<IEnumerable<GetClientAirportJMDTO>> GetClientAirportJM()
    {
        //Por tipo de cliente, obtener los nombres y el tipo de los clientes del aeropuerto internacional José Martí que han arribado a la misma en sus propias naves como capitanes. 
        var flights = await _context.Flights
            .Include(x => x.Client)
            .Where(x => x.AirportDestination.Name == "Jose Marti" && x.ArrivedClientType == ArrivedClientType.Captain)
            .ToListAsync();
        
        var result = new List<GetClientAirportJMDTO>();
        foreach (var flight in flights)
        {
            result.Add(new GetClientAirportJMDTO()
            {
                NameClient = flight.Client.Name,
                ClientType = flight.Client.ClientType.Type
            });
        }
        
        return result;
    }

    public async Task<string> DeleteInneficientServices(DeleteInneficientServicesDTO dto)
    {
        var airport = await _context.Airports.Include(x => x.Installations)
            .ThenInclude(x => x.Services)
            .FirstOrDefaultAsync(x => x.Id == dto.Id);
        if (airport == null) return "Airport not found";
        var allClientServices = await _context.ClientServices.ToListAsync();
        var allRepairServices = await _context.Repairs.ToListAsync();
        foreach (var installation in airport.Installations)
        {
            foreach (var service in installation.Services)
            {
                if(allClientServices.Any(x => x.IdService == service.Id))
                {
                    var clientService = allClientServices.Where(x => x.IdService == service.Id);
                    if (clientService.Average(x => x.Rating) <= 3)
                    {
                        _context.Services.Remove(service);
                    }
                }
                else if (allRepairServices.Any(x => x.IdService == service.Id))
                {
                    var repairService = allRepairServices.Where(x => x.IdService == service.Id);
                    if(repairService.Average(x => x.Rating) <= 3)
                    {
                        _context.Services.Remove(service);
                    }
                }
            }
        }
        await _context.SaveChangesAsync();
        return "Inneficient services deleted";
    }
}