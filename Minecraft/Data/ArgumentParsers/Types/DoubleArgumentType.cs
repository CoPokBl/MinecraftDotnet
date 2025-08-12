using Minecraft.Schemas;

namespace Minecraft.Data.ArgumentParsers.Types;

public record DoubleArgumentType(int ProtocolId, double? Min = null, double? Max = null) 
    : NumberArgumentType<double>(ProtocolId, Min, Max) {
    
    public override Identifier Identifier => "brigadier:double";
    public override Action<DataWriter, double> Writer { get; } = (writer, value) => writer.WriteDouble(value);
    public override Func<DataReader, double> Reader { get; } = reader => reader.ReadDouble();
}
