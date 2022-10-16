using HTML2PDF.Service;
using Microsoft.AspNetCore.Mvc;

namespace HTML2PDF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PdfController : ControllerBase
    {
        private readonly IPdfService _pdfService;
        public const string FileDirectory = "test";

        public PdfController(IPdfService pdfService)
        {
            _pdfService = pdfService;
        }

        [HttpPost]
        public async Task<IActionResult> Create()
        {
            byte[] bytes = await _pdfService.CreateAsync("<h1>dupa</h1>");

            if (!Directory.Exists(FileDirectory))
            {
                Directory.CreateDirectory(FileDirectory);
            }
            await System.IO.File.WriteAllBytesAsync($"{FileDirectory}/hello.pdf", bytes);

            return Ok();
        }
    }
}
