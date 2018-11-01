using Metal.Sharp;

namespace MetalsharpFluidTemplate
{
    public static class MetalsharpExtension
    {
        public static Metalsharp UseFluidTemplate(this Metalsharp directory) =>
            directory.Use(new FluidTemplate());
    }
}
