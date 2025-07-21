using Minecraft.Registry;

namespace Minecraft.Data;

/// <summary>
/// Defines a type that can be read from or written to a data stream.
/// </summary>
/// <typeparam name="T">The type of this network type.</typeparam>
public interface INetworkType<in T> {
    // This needs to be static, because otherwise I need an instance
    // public T ReadData(DataReader reader, MinecraftRegistry registry);
    public DataWriter WriteData(T val, DataWriter writer, MinecraftRegistry registry);
}
