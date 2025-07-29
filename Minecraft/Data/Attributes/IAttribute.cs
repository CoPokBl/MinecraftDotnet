namespace Minecraft.Data.Attributes;

public interface IAttribute : IProtocolType {
    public double Default { get; }
    public double Min { get; }
    public double Max { get; }
}
