using HTML2PDF.RazorEngine.Templates;
using Microsoft.Extensions.DependencyInjection;

namespace HTML2PDF.RazorEngine
{
    public interface IRazorService
    {
        string CreateHtml<T>(T model, string templateView);
    }

    public class RazorService : IRazorService
    {
        public string CreateHtml<T>(T model, string templateView)
        {
            RazorEngineCore.RazorEngine razorEngine = new RazorEngineCore.RazorEngine();
            CompiledTemplate<RazorTemplate<T>, T> compiled = razorEngine.CompileTemplate<T>(templateView);
            return compiled.Run(model);
        }
    }

    public static class RazorServiceExtension
    {
        public static void AddRazorEngineService(this IServiceCollection services)
        {
            services.AddTransient<IRazorService, RazorService>();
        }
    }
}