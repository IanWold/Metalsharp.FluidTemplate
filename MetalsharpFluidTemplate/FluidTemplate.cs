using Fluid;
using Metal.Sharp;
using System.Linq;

namespace MetalsharpFluidTemplate
{
    public class FluidTemplate : IMetalsharpPlugin
    {
        public Metalsharp Execute(Metalsharp directory)
        {
            foreach (var file in directory.OutputFiles.Where(i => i.Extension == "html"))
            {
                if (file.Metadata.TryGetValue("template", out var _templatePath)
                    && _templatePath is string templatePath
                    && directory.InputFiles.FirstOrDefault(i => i.FilePath == templatePath) is MetalsharpFile templateFile)
                {
                    if (Fluid.FluidTemplate.TryParse(templateFile.Text, out Fluid.FluidTemplate template))
                    {
                        var context = new TemplateContext();

                        context.MemberAccessStrategy.Register<string>();
                        context.SetValue("content", file.Text);

                        foreach (var meta in file.Metadata)
                        {
                            var valueType = meta.Value.GetType();
                            context.MemberAccessStrategy.Register(valueType);
                            context.SetValue(meta.Key, meta.Value);
                        }

                        file.Text = template.Render(context);
                    }
                }
            }

            return directory;
        }
    }
}
