using Minecraft.Schemas;

namespace Minecraft.Data.ArgumentParsers.Types;

public record IntegerArgumentType(int? Min = null, int? Max = null)
    : NumberArgumentType<int>(Min, Max) {

    public override Identifier Identifier => "brigadier:integer";
    public override Action<DataWriter, int> Writer { get; } = (writer, value) => writer.WriteInteger(value);
    public override Func<DataReader, int> Reader { get; } = reader => reader.ReadInteger();
}
