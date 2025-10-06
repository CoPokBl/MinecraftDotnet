using Minecraft.Data.Enchantments;
using Minecraft.Registry;
using Minecraft.Schemas;

namespace Minecraft.Data.Components.Types;

public record EnchantmentsComponent(int ProtocolId) : IDataComponent<(IEnchantment, int)[]> {
    public override Identifier Identifier => "minecraft:enchantments";

    public override DataWriter WriteData((IEnchantment, int)[] val, DataWriter writer, MinecraftRegistry registry) {
        return writer.WritePrefixedArray(val, (tuple, w) => w
            .WriteVarInt(tuple.Item1.ProtocolId)
            .WriteVarInt(tuple.Item2));
    }

    public override (IEnchantment, int)[] ReadData(DataReader reader, MinecraftRegistry registry) {
        (IEnchantment, int)[] enchantments = reader.ReadPrefixedArray(r => 
            (registry.Enchantments[r.ReadVarInt()], r.ReadVarInt()));
        return enchantments;
    }
}
