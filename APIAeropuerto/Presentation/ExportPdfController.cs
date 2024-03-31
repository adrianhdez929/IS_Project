using APIAeropuerto.Application.UseCases.ExportPdf;
using Microsoft.AspNetCore.Mvc;

namespace APIAeropuerto.Presentation;

[ApiController]
[Route("api/[controller]")]
public class ExportPdfController : Controller
{
    private readonly ExportPdfUseCase _exportPdfUseCase;
    
    public ExportPdfController(ExportPdfUseCase exportPdfUseCase)
    {
        _exportPdfUseCase = exportPdfUseCase;
    }
    
    [HttpPost]
    [Route("export/{path}")]
    public async Task<IActionResult> ExportPdf(string path)
    {
        _exportPdfUseCase.Execute(path);
        return Ok("Pdf exported successfully!");
    }
}