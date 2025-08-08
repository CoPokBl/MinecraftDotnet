using Minecraft.Registry;

namespace Minecraft.Data.ArgumentParsers;

public interface IArgumentParser<T> : IArgumentParser {
    public T Parse(string str);
    public string Format(T value);
}

public interface IArgumentParser : IProtocolType {
    public DataWriter WriteData(DataWriter writer, MinecraftRegistry registry);
    public IArgumentParser ReadData(DataReader reader, MinecraftRegistry registry);
}
