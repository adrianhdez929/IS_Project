using APIAeropuerto.Application.DTOs.InstallationType;
using APIAeropuerto.Application.UseCases.InstallationType;
using APIAeropuerto.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace APIAeropuerto.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class InstallationTypeController : Controller
{
    private readonly IUseCase<InstallationTypeDTO,CreateInstallationTypeDTO> _createInstallationTypeUseCase;
    private readonly IUseCase<InstallationTypeDTO,UpdateInstallationTypeDTO> _updateInstallationTypeUseCase;
    private readonly IUseCase<string,DeleteInstallationTypeDTO> _deleteInstallationTypeUseCase;
    private readonly IUseCase<InstallationTypeDTO,GetOneInstallationTypeDTO> _getOneInstallationTypeUseCase;
    private readonly GetAllInstallationTypeUseCase _getAllInstallationTypeUseCase;
    
    public InstallationTypeController(IUseCase<InstallationTypeDTO,CreateInstallationTypeDTO> createInstallationTypeUseCase, IUseCase<InstallationTypeDTO,UpdateInstallationTypeDTO> updateInstallationTypeUseCase, IUseCase<string,DeleteInstallationTypeDTO> deleteInstallationTypeUseCase, IUseCase<InstallationTypeDTO,GetOneInstallationTypeDTO> getOneInstallationTypeUseCase, GetAllInstallationTypeUseCase getAllInstallationTypeUseCase)
    {
        _createInstallationTypeUseCase = createInstallationTypeUseCase;
        _updateInstallationTypeUseCase = updateInstallationTypeUseCase;
        _deleteInstallationTypeUseCase = deleteInstallationTypeUseCase;
        _getOneInstallationTypeUseCase = getOneInstallationTypeUseCase;
        _getAllInstallationTypeUseCase = getAllInstallationTypeUseCase;
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateInstallationType([FromBody] CreateInstallationTypeDTO dto)
    {
        var result = await _createInstallationTypeUseCase.Execute(dto);
        return Ok(result);
    }
    
    [HttpPut]
    public async Task<IActionResult> UpdateInstallationType([FromBody] UpdateInstallationTypeDTO dto)
    {
        var result = await _updateInstallationTypeUseCase.Execute(dto);
        return Ok(result);
    }
    
    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> DeleteInstallationType(Guid id)
    {
        var result = await _deleteInstallationTypeUseCase.Execute(new DeleteInstallationTypeDTO(){Id = id});
        return Ok(result);
    }
    
    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> GetOneInstallationType(Guid id)
    {
        var result = await _getOneInstallationTypeUseCase.Execute(new GetOneInstallationTypeDTO(){Id = id});
        return Ok(result);
    }
    
    [HttpGet]
    [Route("all")]
    public async Task<IActionResult> GetAllInstallationType()
    {
        var result = await _getAllInstallationTypeUseCase.Execute();
        return Ok(result);
    }
}