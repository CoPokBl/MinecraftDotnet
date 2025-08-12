using Minecraft.Schemas;

namespace Minecraft.Data.ArgumentParsers.Types;

public record LongArgumentType(int ProtocolId, long? Min = null, long? Max = null)
    : NumberArgumentType<long>(ProtocolId, Min, Max) {

    public override Identifier Identifier => "brigadier:long";
    public override Action<DataWriter, long> Writer { get; } = (writer, value) => writer.WriteLong(value);
    public override Func<DataReader, long> Reader { get; } = reader => reader.ReadLong();
}
