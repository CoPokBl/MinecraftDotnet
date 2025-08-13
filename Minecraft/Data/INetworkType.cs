using Minecraft.Registry;

namespace Minecraft.Data;

/// <summary>
/// Defines a type that can be read from or written to a data stream.
/// </summary>
/// <typeparam name="T">The type of this network type.</typeparam>
public interface INetworkType<out T> {
    public DataWriter WriteData(DataWriter writer, MinecraftRegistry registry);

    public static abstract T ReadData(DataReader reader, MinecraftRegistry registry);
}
