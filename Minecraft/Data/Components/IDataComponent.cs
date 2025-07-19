using Minecraft.Registry;
using Minecraft.Schemas;

namespace Minecraft.Data.Components;

public abstract record IDataComponent<T> : IDataComponent {
    public abstract int ProtocolId { get; init; }
    public abstract Identifier Identifier { get; }
    
    public abstract DataWriter WriteData(T val, DataWriter writer, MinecraftRegistry registry);
    public abstract object ReadData(DataReader reader, MinecraftRegistry registry);

    public DataWriter WriteData(object val, DataWriter writer, MinecraftRegistry registry) {
        return WriteData((T)val, writer, registry);
    }

    public override int GetHashCode() {
        return Identifier.GetHashCode();
    }
}

/// <summary>
/// Generic interface for data components in Minecraft.
/// </summary>
public interface IDataComponent : IProtocolType {
    public DataWriter WriteData(object val, DataWriter writer, MinecraftRegistry registry);
    public object ReadData(DataReader reader, MinecraftRegistry registry);
}
