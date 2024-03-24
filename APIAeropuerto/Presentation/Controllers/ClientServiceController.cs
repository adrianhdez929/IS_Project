using APIAeropuerto.Application.DTOs.ClientService;
using APIAeropuerto.Domain.Interfaces;
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
    public async Task<IActionResult> Delete(Guid idClient, Guid idService)
    {
        var result = await _deleteClientServiceUseCase.Execute(new DeleteClientServiceDTO()
            { IdClient = idClient, IdService = idService });
        return Ok(result);
    }
}