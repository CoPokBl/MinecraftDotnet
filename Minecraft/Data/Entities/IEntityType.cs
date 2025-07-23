namespace Minecraft.Data.Entities;

public interface IEntityType : IProtocolType {
    public bool FireImmune { get; }
    public double Width { get; }
    public double Height { get; }
    public double EyeHeight { get; }
}
