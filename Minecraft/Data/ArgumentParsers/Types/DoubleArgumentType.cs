using System.Globalization;
using Minecraft.Registry;
using Minecraft.Schemas;

namespace Minecraft.Data.ArgumentParsers.Types;

public record DoubleArgumentType(int ProtocolId, double? Min = null, double? Max = null) : IArgumentParser<double> {
    public Identifier Identifier => "brigadier:double";

    public DataWriter WriteData(DataWriter writer, MinecraftRegistry registry) {
        return writer
            .WriteByte(0 | (byte)(Min.HasValue ? 1 : 0) | (byte)(Max.HasValue ? 2 : 0))
            .WriteIfPresent(Min, (d, w) => w.WriteDouble(d))
            .WriteIfPresent(Max, (d, w) => w.WriteDouble(d));
    }

    public IArgumentParser ReadData(DataReader reader, MinecraftRegistry registry) {
        sbyte flags = reader.ReadByte();
        double? min = (flags & 1) != 0 ? reader.ReadDouble() : null;
        double? max = (flags & 2) != 0 ? reader.ReadDouble() : null;
        return new DoubleArgumentType(ProtocolId, min, max);
    }

    public object GenericParse(string str) => Parse(str);
    public string Format(object value) => Format((double)value);

    public double Parse(string str) {
        return double.Parse(str);
    }

    public string Format(double value) {
        return value.ToString(CultureInfo.InvariantCulture);
    }
}
