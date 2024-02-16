using APIAeropuerto.Application.DTOs.Installations;
using APIAeropuerto.Application.UseCases.Installations;
using APIAeropuerto.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace APIAeropuerto.Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class InstallationController : Controller
{
    private readonly IUseCase<InstallationDTO,CreateInstallationsDTO> _createInstallationUseCase;
    private readonly IUseCase<InstallationDTO,UpdateInstallationDTO> _updateInstallationUseCase;
    private readonly IUseCase<string,DeleteInstallationDTO> _deleteInstallationUseCase;
    private readonly IUseCase<InstallationDTO,GetOneInstallationDTO> _getOneInstallationUseCase;
    private readonly IUseCase<GetInstallationServicesDTO, GetOneInstallationDTO> _getInstallationServicesUseCase;
    private readonly GetAllInstallationUseCase _getAllInstallationUseCase;
    public InstallationController(
        IUseCase<InstallationDTO,CreateInstallationsDTO> createInstallationUseCase,
        IUseCase<InstallationDTO,UpdateInstallationDTO> updateInstallationUseCase,
        IUseCase<string,DeleteInstallationDTO> deleteInstallationUseCase,
        IUseCase<InstallationDTO,GetOneInstallationDTO> getOneInstallationUseCase,
        IUseCase<GetInstallationServicesDTO, GetOneInstallationDTO> getInstallationServicesUseCase,
        GetAllInstallationUseCase getAllInstallationUseCase
        )
    {
        _createInstallationUseCase = createInstallationUseCase;
        _updateInstallationUseCase = updateInstallationUseCase;
        _deleteInstallationUseCase = deleteInstallationUseCase;
        _getOneInstallationUseCase = getOneInstallationUseCase;
        _getInstallationServicesUseCase = getInstallationServicesUseCase;
        _getAllInstallationUseCase = getAllInstallationUseCase;
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateInstallation([FromBody] CreateInstallationsDTO dto)
    {
        var result = await _createInstallationUseCase.Execute(dto);
        return Ok(result);
    }
    [HttpGet]
    [Route("all")]
    public async Task<IActionResult> GetAllInstallations()
    {
        var result = await _getAllInstallationUseCase.Execute();
        return Ok(result);
    }
    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> GetOneInstallation(Guid id)
    {
        var result = await _getOneInstallationUseCase.Execute(new GetOneInstallationDTO { Id = id });
        return Ok(result);
    }

    [HttpGet]
    [Route("Services/{id}")]
    public async Task<IActionResult> GetInstallationServices(Guid id)
    {
        var result = await _getInstallationServicesUseCase.Execute(new GetOneInstallationDTO() { Id = id });
        return Ok(result);
    }
    [HttpPut]
    public async Task<IActionResult> UpdateInstallation([FromBody] UpdateInstallationDTO dto)
    {
        var result = await _updateInstallationUseCase.Execute(dto);
        return Ok(result);
    }
    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> DeleteInstallation(Guid id)
    {
        var result = await _deleteInstallationUseCase.Execute(new DeleteInstallationDTO { Id = id });
        return Ok(result);
    }
}