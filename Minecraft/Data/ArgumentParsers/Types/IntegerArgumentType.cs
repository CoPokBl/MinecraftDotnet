using Minecraft.Schemas;

namespace Minecraft.Data.ArgumentParsers.Types;

public record IntegerArgumentType(int ProtocolId, int? Min = null, int? Max = null)
    : NumberArgumentType<int>(ProtocolId, Min, Max) {

    public override Identifier Identifier => "brigadier:integer";
    public override Action<DataWriter, int> Writer { get; } = (writer, value) => writer.WriteInteger(value);
    public override Func<DataReader, int> Reader { get; } = reader => reader.ReadInteger();
}
