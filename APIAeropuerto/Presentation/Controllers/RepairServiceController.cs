using APIAeropuerto.Application.DTOs.Services;
using APIAeropuerto.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace APIAeropuerto.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RepairServiceController : Controller
{
    private readonly IUseCase<ServiceDTO, CreateRepairServiceDTO> _useCase;

    public RepairServiceController(IUseCase<ServiceDTO, CreateRepairServiceDTO> useCase)
    {
        _useCase = useCase;
    }

    [HttpPost]
    public async Task<IActionResult> CreateRepairService([FromBody] CreateRepairServiceDTO dto)
    {
        var result = await _useCase.Execute(dto);
        return Ok(result);
    }
}