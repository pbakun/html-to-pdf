using HTML2PDF.Model.Template;
using HTML2PDF.RazorEngine;
using HTML2PDF.Service;
using Microsoft.AspNetCore.Mvc;

namespace HTML2PDF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PdfController : ControllerBase
    {
        private readonly IPdfService _pdfService;
        private readonly IRazorService _razorService;
        public const string FileDirectory = "test";

        public PdfController(IPdfService pdfService, IRazorService razorService)
        {
            _pdfService = pdfService;
            _razorService = razorService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(Invoice invoice)
        {
            string path = Directory.GetCurrentDirectory() + "/Templates/Invoice.cshtml";
            var razorTemplate = await System.IO.File.ReadAllTextAsync(path);

            var html = _razorService.CreateHtml(invoice, razorTemplate);
            byte[] bytes = await _pdfService.CreateAsync(html);

            if (!Directory.Exists(FileDirectory))
            {
                Directory.CreateDirectory(FileDirectory);
            }
            await System.IO.File.WriteAllBytesAsync($"{FileDirectory}/hello.pdf", bytes);

            return Ok();
        }
    }
}
