using APIAeropuerto.Application.DTOs.ClientService;
using APIAeropuerto.Domain.Interfaces;
using APIAeropuerto.Domain.Shared;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace APIAeropuerto.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClientServiceController : Controller
{
    private readonly IUseCase<string, DeleteClientServiceDTO> _deleteClientServiceUseCase;

    public ClientServiceController(IUseCase<string, DeleteClientServiceDTO> deleteClientServiceUseCase)
    {
        _deleteClientServiceUseCase = deleteClientServiceUseCase;
    }

    [HttpDelete]
    [Route("{idClient},{idService}")]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = ClaimsStrings.WriteClientServices)]
    public async Task<IActionResult> Delete(Guid idClient, Guid idService)
    {
        var result = await _deleteClientServiceUseCase.Execute(new DeleteClientServiceDTO()
            { IdClient = idClient, IdService = idService });
        return Ok(result);
    }
}