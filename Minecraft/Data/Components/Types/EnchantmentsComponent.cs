using Minecraft.Registry;
using Minecraft.Schemas;

namespace Minecraft.Data.Components.Types;

public record EnchantmentsComponent(int ProtocolId) : IDataComponent<(int, int)[]> {
    public override Identifier Identifier => "minecraft:enchantments";

    public override DataWriter WriteData((int, int)[] val, DataWriter writer, MinecraftRegistry registry) {
        return writer.WritePrefixedArray(val, (tuple, w) => w
            .WriteVarInt(tuple.Item1)
            .WriteVarInt(tuple.Item2));
    }

    public override (int, int)[] ReadData(DataReader reader, MinecraftRegistry registry) {
        (int, int)[] enchantments = reader.ReadPrefixedArray(r => 
            (r.ReadVarInt(), r.ReadVarInt()));
        return enchantments;
    }
}
