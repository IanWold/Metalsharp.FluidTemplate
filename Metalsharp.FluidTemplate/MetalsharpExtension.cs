namespace Metalsharp.FluidTemplate
{
    public static class MetalsharpExtension
    {
        public static MetalsharpProject UseFluidTemplate(this MetalsharpProject project) =>
            project.Use(new FluidTemplate());

        public static MetalsharpProject UseFluidTemplate(this MetalsharpProject project, string layoutFile) =>
            project.Use(new FluidTemplate(layoutFile));
    }
}
