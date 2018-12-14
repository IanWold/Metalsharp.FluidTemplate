using Fluid;
using System.Linq;

namespace Metalsharp.FluidTemplate
{
    public class FluidTemplate : IMetalsharpPlugin
    {
        private string _layoutPath;

        public FluidTemplate() =>
            _layoutPath = null;

        public FluidTemplate(string layoutPath) =>
            _layoutPath = layoutPath;

        public void Execute(MetalsharpProject project)
        {
            foreach (var file in project.OutputFiles.Where(i => i.Extension == ".html"))
            {
                var context = new TemplateContext();

                context.MemberAccessStrategy.Register<string>();
                context.SetValue("content", file.Text);

                foreach (var meta in file.Metadata)
                {
                    var valueType = meta.Value.GetType();
                    valueType.GetGenericArguments().ToList().ForEach(t => context.MemberAccessStrategy.Register(t));

                    context.MemberAccessStrategy.Register(valueType);
                    context.SetValue(meta.Key, meta.Value);
                }

                if (file.Metadata.TryGetValue("template", out var _templatePath)
                    && _templatePath is string templatePath
                    && project.InputFiles.FirstOrDefault(i => i.FilePath == templatePath) is IMetalsharpFile templateFile
                    && Fluid.FluidTemplate.TryParse(templateFile.Text, out Fluid.FluidTemplate template))
                {
                    file.Text = template.Render(context);
                }

                if (!string.IsNullOrEmpty(_layoutPath)
                    && project.InputFiles.FirstOrDefault(i => i.FilePath == _layoutPath) is IMetalsharpFile layoutFile
                    && Fluid.FluidTemplate.TryParse(layoutFile.Text, out Fluid.FluidTemplate layout))
                {
                    context.SetValue("content", file.Text);

                    file.Text = layout.Render(context);
                }
            }
        }
    }
}
