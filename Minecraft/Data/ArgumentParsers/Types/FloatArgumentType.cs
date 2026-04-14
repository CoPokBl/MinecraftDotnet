using Minecraft.Schemas;

namespace Minecraft.Data.ArgumentParsers.Types;

public record FloatArgumentType(float? Min = null, float? Max = null)
    : NumberArgumentType<float>(Min, Max) {
    
    public override Identifier Identifier => "brigadier:float";
    public override Action<DataWriter, float> Writer { get; } = (writer, value) => writer.WriteFloat(value);
    public override Func<DataReader, float> Reader { get; } = reader => reader.ReadFloat();
}
