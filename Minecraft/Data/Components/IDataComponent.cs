using Minecraft.Registry;
using Minecraft.Schemas;

namespace Minecraft.Data.Components;

public interface IDataComponent<out T> : IDataComponent {
    public T Value { get; }
}

/// <summary>
/// Generic interface for data components in Minecraft.
/// </summary>
public interface IDataComponent {
    public Identifier Identifier { get; }
    
    public DataWriter WriteData(DataWriter writer, MinecraftRegistry registry);
    public IDataComponent ReadData(DataReader reader, MinecraftRegistry registry);
}
