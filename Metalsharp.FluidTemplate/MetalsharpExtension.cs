namespace Metalsharp.FluidTemplate
{
    public static class MetalsharpExtension
    {
        public static MetalsharpDirectory UseFluidTemplate(this MetalsharpDirectory directory) =>
            directory.Use(new FluidTemplate());
    }
}
