using Minecraft.Registry;

namespace Minecraft.Data;

public interface INetworkType<T> {
    public T ReadData(DataReader reader, MinecraftRegistry registry);
    public DataWriter WriteData(T val, DataWriter writer, MinecraftRegistry registry);
}
