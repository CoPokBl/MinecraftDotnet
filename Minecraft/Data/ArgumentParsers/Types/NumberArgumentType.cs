using System.Numerics;
using Minecraft.Registry;

namespace Minecraft.Data.ArgumentParsers.Types;

public abstract record NumberArgumentType<T>(int ProtocolId, T? Min = null, T? Max = null) 
    : ArgumentParser<T>(ProtocolId) where T : struct, INumberBase<T> {
    
    public abstract Action<DataWriter, T> Writer { get; }
    public abstract Func<DataReader, T> Reader { get; }

    public override DataWriter WriteData(DataWriter writer, MinecraftRegistry registry) {
        return writer
            .WriteByte(0 | (byte)(Min.HasValue ? 1 : 0) | (byte)(Max.HasValue ? 2 : 0))
            .WriteIfPresent(Min, (d, w) => Writer(w, d))
            .WriteIfPresent(Max, (d, w) => Writer(w, d));
    }

    public override IArgumentParser ReadData(DataReader reader, MinecraftRegistry registry) {
        sbyte flags = reader.ReadByte();
        T? min = (flags & 1) != 0 ? Reader(reader) : null;
        T? max = (flags & 2) != 0 ? Reader(reader) : null;
        return this with {
            Min = min,
            Max = max
        };
    }

    public override T Parse(ref string str, MinecraftRegistry _) {
        string numStr = str.Split(' ')[0];
        str = str.Length > numStr.Length ? str[(numStr.Length + 1)..] : string.Empty;
        return T.Parse(numStr, null);
    }

    public override string Format(T value) {
        return value.ToString()!;
    }
}
