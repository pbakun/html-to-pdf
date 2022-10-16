using Microsoft.AspNetCore.Mvc;
using Microsoft.Playwright;

namespace HTML2PDF.Service
{
    public interface IPdfService
    {
        Task<byte[]> CreateAsync(string html);
    }
    public class PdfService : IPdfService
    {
        public async Task<byte[]> CreateAsync(string html)
        {
            using var playwright = await Playwright.CreateAsync();
            await using var browser = await playwright.Chromium.LaunchAsync();
            var page = await browser.NewPageAsync();
            await page.EmulateMediaAsync(new PageEmulateMediaOptions { Media = Media.Screen });
            await page.SetContentAsync(html, new PageSetContentOptions() { WaitUntil = WaitUntilState.Load });
            return await page.PdfAsync(new PagePdfOptions { Format = "A4" });
        }
    }
}
