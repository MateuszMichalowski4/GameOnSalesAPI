using Microsoft.AspNetCore.Mvc;
using System.IO;
using FreeGamesAPI.Models;
[ApiController]
[Route("[controller]")]
public class PdfController : ControllerBase
{
    private readonly PdfService _pdfService;

    public PdfController(PdfService pdfService)
    {
        _pdfService = pdfService;
    }

    [HttpGet("generatepdf/{fileName}")]
    public IActionResult GeneratePdf(string fileName, string name, string surname,string email,string education, string experience, string phoneNumber, string languages, string interests, string githubLink)
    {
        var pdfBytes = _pdfService.GeneratePdf(name, surname,email,education, experience, phoneNumber, languages, interests, githubLink);

        return File(pdfBytes, "application/pdf", fileName + ".pdf");
    }
}

