using Minecraft.Registry;

namespace Minecraft.Data.ArgumentParsers;

public interface IArgumentParser<T> : IArgumentParser {
    public T Parse(ref string str, MinecraftRegistry reg);  // Parses the argument from the string, modifying it in place.
    public string Format(T value);
}

public interface IArgumentParser : IProtocolType {
    public object GenericParse(ref string str, MinecraftRegistry reg);
    public string Format(object value);
    
    public DataWriter WriteData(DataWriter writer, MinecraftRegistry registry);
    public IArgumentParser ReadData(DataReader reader, MinecraftRegistry registry);
}
