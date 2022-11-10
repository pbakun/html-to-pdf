using RazorEngineCore;

namespace HTML2PDF.RazorEngine.Templates
{
    public class CompiledTemplate<TTemplate, TModel> where TTemplate : RazorTemplate<TModel>
    {
        private readonly IRazorEngineCompiledTemplate<TTemplate> _compiledTemplate;

        public CompiledTemplate(IRazorEngineCompiledTemplate<TTemplate> compiledTemplate)
        {
            _compiledTemplate = compiledTemplate;
        }

        public string Run(TModel model)
        {
            return _compiledTemplate.Run(instance =>
            {
                instance.Model = model;
            });
        }
    }

    public static class CompiledTemplateExtensions
    {
        public static CompiledTemplate<RazorTemplate<TModel>, TModel> 
            CompileTemplate<TModel>(this RazorEngineCore.RazorEngine razorEngine, string template)
        {
            Action<IRazorEngineCompilationOptionsBuilder> compilationOptionsBuilder = delegate (IRazorEngineCompilationOptionsBuilder builder)
            {
                builder.AddAssemblyReferenceByName("System.Globalization");
                builder.AddAssemblyReferenceByName("System.Runtime");
                builder.AddAssemblyReference(typeof(DateTime));
                //builder.AddAssemblyReferenceByName("System.Linq");
            };

            return new CompiledTemplate<RazorTemplate<TModel>, TModel>(
                razorEngine.Compile<RazorTemplate<TModel>>(template, compilationOptionsBuilder));
        }

    }
}
