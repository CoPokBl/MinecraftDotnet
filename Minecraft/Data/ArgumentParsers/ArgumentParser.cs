using Minecraft.Registry;
using Minecraft.Schemas;

namespace Minecraft.Data.ArgumentParsers;

public abstract record ArgumentParser<T>(int ProtocolId) : IArgumentParser<T> {
    public abstract Identifier Identifier { get; }

    public virtual DataWriter WriteData(DataWriter writer, MinecraftRegistry registry) {
        return writer;
    }

    public virtual IArgumentParser ReadData(DataReader reader, MinecraftRegistry registry) {
        return this;
    }

    public object GenericParse(ref string str, MinecraftRegistry reg) => Parse(ref str, reg)!;
    public string Format(object value) => Format((T)value);

    public abstract T Parse(ref string str, MinecraftRegistry reg);
    public abstract string Format(T value);
}
